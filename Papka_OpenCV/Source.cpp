#include "opencv2/highgui/highgui.hpp" //определяет кросс-платформенные функции взаимодействия с оконной системой
#include "opencv2/imgproc/imgproc.hpp"

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>

using namespace cv;
using namespace std;

int main(int argc, char** argv)
{
	int height = 1080;
	int width = 1920;
	Mat img(height, width, CV_8UC3);
	setlocale(LC_ALL, "Russian");

	Point textOrg(100, img.rows / 2);
	int fontFace = FONT_HERSHEY_SCRIPT_SIMPLEX;
	double fontScale = 2;
	int fontSize = 25;
	Scalar color(200, 100, 50);
	putText(img, "OpenCV Step By Step", textOrg, fontFace, fontFace, color, fontSize);

	imshow("Hello World", img);


	img = imread("maxresdefault.jpg", 1);
	
	char filename[80];
	cout << "Ââåäèòå èìÿ ôàéëà, â êîòîðûé õîòèòå âíåñòè èçìåíåíèÿ, è íàæìèòå Enter" << endl;
	cin.getline(filename, 80);
	cout << "Îòêðûò ôàéë";
	cout << filename << endl;
	
	namedWindow("Èñõîäíîå èçîáðàæåíèå", WINDOW_AUTOSIZE);
	imshow("Èñõîäíîå èçîáðàæåíèå", img);

	Mat src_gary;
	Mat _img;
	Mat canny_output;

	cvtColor(img, src_gary, COLOR_RGB2GRAY);
	blur(src_gary, src_gary, Size(3, 3));
	
	double otsu_thresh_val = threshold(src_gary, img, 0, 255, THRESH_BINARY | THRESH_OTSU);
	double high_thresh_val = otsu_thresh_val, lower_thresh_val = otsu_thresh_val * 0.5;
	cout << otsu_thresh_val;
	Canny(src_gary, canny_output, lower_thresh_val, high_thresh_val, 3);

	namedWindow("Ñåðîå èçîáðàæåíèå", WINDOW_AUTOSIZE);
	imshow("Ñåðîå èçîáðàæåíèå", canny_output);
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
		printf("Êîíòóð ¹ %d: öåíòð ìàññ - õ = %.2f, äëèíà - %.2f \n", i,
			mu[i].m10 / mu[i].m00, mu[i].m01 / mu[i].m00, arcLength(contours[i], true));
	}

	Mat drawning = Mat::zeros(canny_output.size(), CV_8UC3);

	for (int i = 0; i < contours.size(); i++)
	{
		Scalar color = Scalar(rng.uniform(0, 255), rng.uniform(0, 255), rng.uniform(0, 255));
		drawContours(drawning, contours, i, color, 2, 8, hierarchy, 0, Point());
		circle(drawning, mc[i], 4, color, -1, 5, 0);
	}

	namedWindow("Êîíòóðû", WINDOW_AUTOSIZE);
	imshow("Êîíòóðû", drawning);

	waitKey(0);
	return 0;
}//maxresdefault.jpg
