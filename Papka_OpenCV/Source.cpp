#include "opencv2/highgui/highgui.hpp" //определяет кросс-платформенные функции взаимодействия с оконной системой
#include "opencv2/imgproc/imgproc.hpp" //определяет основные/традиционные функции цифровой обработки изображений: отрисовка кривых и тому подобное

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>

using namespace cv; //пространство имён OpenCV
using namespace std; //пространство имён С++

int main(int argc, char** argv)
{
	int height = 1080;
	int width = 1920;
	Mat img(height, width, CV_8UC3); //создаётся изображение заданной ширены и высоты с 3-х канальным цветом
	setlocale(LC_ALL, "Russian"); //переводит на русский текст введённый в консоли

	Point textOrg(100, img.rows / 2); //изменение положения текста по вертикали
	int fontFace = FONT_HERSHEY_SCRIPT_SIMPLEX; //Стиль текста
	
	char filename[80];
	cout << "Введите имя файла, в который хотите внести изменения, и нажмите Enter" << endl;
	cin.getline(filename, 80);
	cout << "Открыт файл";
	cout << filename << endl; //запрашиваем у пользователя название файла

	int fontScale;
	cout << "Введите размер шрифта и нажмите Enter" << endl;
	cin>>fontScale;
	cout << "Изменён шрифт на: " << fontScale << endl; //запрашиваем у пользователя размер шрифта

	int fontSize;
	cout << "Введите ширину шрифта и нажмите Enter" << endl;
	cin >> fontSize;
	cout << "Изменён шрифт на: " << fontSize << endl; //запрашиваем у пользователя ширину шрифта
	
	Scalar color(200, 100, 50); //цвет текста
	
	putText(img, "OpenCV Step By Step", textOrg, fontFace, fontScale, color, fontSize); //создаём текст используя все переменные введёные для него ранее

	imshow("Hello World", img); //название окна

	img = imread(filename, 1); //сохраняет введённое изображение указанное пользователем в матрицу

	namedWindow("Исходное изображение", WINDOW_AUTOSIZE);
	imshow("Исходное изображение", img); //называет и выводит окно с изображением

	Mat src_gary;
	Mat _img;
	Mat canny_output; //матрицы

	cvtColor(img, src_gary, COLOR_RGB2GRAY);
	blur(src_gary, src_gary, Size(3, 3));

	double otsu_thresh_val = threshold(src_gary, img, 0, 255, THRESH_BINARY | THRESH_OTSU);
	double high_thresh_val = otsu_thresh_val, lower_thresh_val = otsu_thresh_val * 0.5;
	cout << otsu_thresh_val;
	Canny(src_gary, canny_output, lower_thresh_val, high_thresh_val, 3);

	namedWindow("Серое изображение", WINDOW_AUTOSIZE);
	imshow("Серое изображение", canny_output);
	imwrite("canny_output.jpg", canny_output);


	RNG rng(12345);
	vector<vector<Point>> contours;
	vector<Vec4i> hierarchy;

	findContours(canny_output, contours, hierarchy, RETR_TREE, CHAIN_APPROX_SIMPLE, Point(0, 0));

	vector<Moments> mu(contours.size());
	for (int i = 0; i < contours.size(); i++)
	{
		mu[i] = moments(contours[i], false);
	}

	vector<Point2f> mc(contours.size());
	for (int i = 0; i < contours.size(); i++)
	{
		mc[i] = Point2f(mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00);
	}

	for (int i = 0; i < contours.size(); i++)
	{
		printf("Контур № %d: центр масс - х = %.2f, длина - %.2f \n", i,
			mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true));
	}

	Mat drawning = Mat::zeros(canny_output.size(), CV_8UC3);

	for (int i = 0; i < contours.size(); i++)
	{
		Scalar color = Scalar(rng.uniform(0, 255), rng.uniform(0, 255), rng.uniform(0, 255));
		drawContours(drawning, contours, i, color, 2, 8, hierarchy, 0, Point());
		circle(drawning, mc[i], 4, color, -1, 5, 0);
	}

	namedWindow("Контуры", WINDOW_AUTOSIZE);
	imshow("Контуры", drawning);
	imwrite("contour.jpg", drawning);

	waitKey(0);
	return 0;
