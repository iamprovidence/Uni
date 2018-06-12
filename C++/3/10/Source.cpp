/*
Завдання 10: (3 бали)

Написати програму для генерування простих текстових звітів. Звіт складається з
тіла звіту, верхнього та нижнього колонтитулів. Передбачити різні типи
колонтитулів і форматування звіту. Виводити звіт у текстовий файл. Текст тіла
звіту задавати у консолі з клавіатури. Використати патерн Builder.
*/
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

class ReportBuilder // Builder
{
protected:
	string file_name;
	string report_text;
	string body;
public:

	virtual void CreateHeader() = 0;
	virtual void CreateBody() = 0;
	virtual void CreateFooter() = 0;

	virtual void Print() 
	{
		ofstream of(file_name);
		of << report_text;
		of.close();
	};
};

struct SimpleReport : public ReportBuilder // ConcreteBuilder1
{
	SimpleReport(string text, string file_name)
	{
		this->file_name = file_name;
		body = text;
	}
	virtual void CreateHeader() 
	{
		report_text.append("\t\tSIMPLE REPORT'S HEADER \n\n");
	};
	virtual void CreateBody() 
	{
		report_text.append(body);
	};
	virtual void CreateFooter() 
	{
		report_text.append("\n\n\t\tSimple Report's Footer");
	};
};

struct HTMLReport : public ReportBuilder // ConcreteBuilder2
{
	HTMLReport(string text, string file_name) 
	{
		body = text;
		this->file_name = file_name;
	}
	virtual void CreateHeader() 
	{
		report_text.append("<HTML>\n\t<BODY> \n");
		report_text.append("\t\t<H1>HTML REPORT'S HEADER</H1> \n");
	};
	virtual void CreateBody() 
	{
		report_text.append("\t\t<p>");
		report_text.append(body);
		report_text.append("\t\t</p>");
	};
	virtual void CreateFooter() 
	{
		report_text.append("\n\t\t<p><i>HTML Report's Footer</i></p> \n");
		report_text.append("\t</BODY>\n</HTML>");
	};
};
// Director. Створює продукт використовуючи інтерфейс Будівельника
void CreateReport(ReportBuilder& report) 
{
	report.CreateHeader();
	report.CreateBody();
	report.CreateFooter();
};

int main()
{
	string text; 
	text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\nNulla eget risus vitae leo tristique cursus et eget elit.\nDonec ultrices aliquet nulla vitae fermentum.\nAenean mauris justo, volutpat vulputate augue sed, placerat ultrices arcu.\nNullam facilisis neque non nunc scelerisque, vitae ultrices quam pretium.\nNullam eu justo a nulla mollis euismod eget at arcu.\nPraesent vehicula eros in auctor commodo.\nNullam molestie, nisi eget aliquet vehicula, mauris justo vehicula nibh, ac sagittis sem justo dignissim erat. \nNulla fermentum ut nulla nec consequat. \nMaecenas nec aliquam quam. \nCurabitur at dolor lacus. Interdum et malesuada fames ac ante ipsum primis in faucibus. \nMaecenas at gravida quam, vel ultrices quam. \nSed tincidunt pellentesque nulla, vel molestie risus interdum ac. \nPraesent vehicula eu velit sed rutrum. \nDonec ultricies venenatis neque, ac egestas est accumsan vitae. Nullam iaculis ut risus non tincidunt. \nSuspendisse potenti. Vestibulum ut iaculis elit, sit amet pulvinar enim. \nVivamus fringilla vitae eros sit amet congue. \nDuis posuere euismod quam et porttitor. Donec facilisis eget massa quis laoreet. \nMaecenas tristique lectus ut venenatis iaculis.\nNulla eget risus vitae leo tristique cursus et eget elit.\nDonec ultrices aliquet nulla vitae fermentum.\nAenean mauris justo, volutpat vulputate augue sed, placerat ultrices arcu.\nNullam facilisis neque non nunc scelerisque, vitae ultrices quam pretium.\nNullam eu justo a nulla mollis euismod eget at arcu.\nPraesent vehicula eros in auctor commodo.\nNullam molestie, nisi eget aliquet vehicula, mauris justo vehicula nibh, ac sagittis sem justo dignissim erat. \nNulla fermentum ut nulla nec consequat. \nMaecenas nec aliquam quam. \nCurabitur at dolor lacus. Interdum et malesuada fames ac ante ipsum primis in faucibus. \nMaecenas at gravida quam, vel ultrices quam. \nSed tincidunt pellentesque nulla, vel molestie risus interdum ac. \nPraesent vehicula eu velit sed rutrum. \nDonec ultricies venenatis neque, ac egestas est accumsan vitae. Nullam iaculis ut risus non tincidunt. \nSuspendisse potenti. Vestibulum ut iaculis elit, sit amet pulvinar enim. \nVivamus fringilla vitae eros sit amet congue. \nDuis posuere euismod quam et porttitor. Donec facilisis eget massa quis laoreet. \nMaecenas tristique lectus ut venenatis iaculis.\nNulla eget risus vitae leo tristique cursus et eget elit.\nDonec ultrices aliquet nulla vitae fermentum.\nAenean mauris justo, volutpat vulputate augue sed, placerat ultrices arcu.\nNullam facilisis neque non nunc scelerisque, vitae ultrices quam pretium.\nNullam eu justo a nulla mollis euismod eget at arcu.\nPraesent vehicula eros in auctor commodo.\nNullam molestie, nisi eget aliquet vehicula, mauris justo vehicula nibh, ac sagittis sem justo dignissim erat. \nNulla fermentum ut nulla nec consequat. \nMaecenas nec aliquam quam. \nCurabitur at dolor lacus. Interdum et malesuada fames ac ante ipsum primis in faucibus. \nMaecenas at gravida quam, vel ultrices quam. \nSed tincidunt pellentesque nulla, vel molestie risus interdum ac. \nPraesent vehicula eu velit sed rutrum. \nDonec ultricies venenatis neque, ac egestas est accumsan vitae. Nullam iaculis ut risus non tincidunt. \nSuspendisse potenti. Vestibulum ut iaculis elit, sit amet pulvinar enim. \nVivamus fringilla vitae eros sit amet congue. \nDuis posuere euismod quam et porttitor. Donec facilisis eget massa quis laoreet. \nMaecenas tristique lectus ut venenatis iaculis.\nNulla eget risus vitae leo tristique cursus et eget elit.\nDonec ultrices aliquet nulla vitae fermentum.\nAenean mauris justo, volutpat vulputate augue sed, placerat ultrices arcu.\nNullam facilisis neque non nunc scelerisque, vitae ultrices quam pretium.\nNullam eu justo a nulla mollis euismod eget at arcu.\nPraesent vehicula eros in auctor commodo.\nNullam molestie, nisi eget aliquet vehicula, mauris justo vehicula nibh, ac sagittis sem justo dignissim erat. \nNulla fermentum ut nulla nec consequat. \nMaecenas nec aliquam quam. \nCurabitur at dolor lacus. Interdum et malesuada fames ac ante ipsum primis in faucibus. \nMaecenas at gravida quam, vel ultrices quam. \nSed tincidunt pellentesque nulla, vel molestie risus interdum ac. \nPraesent vehicula eu velit sed rutrum. \nDonec ultricies venenatis neque, ac egestas est accumsan vitae. Nullam iaculis ut risus non tincidunt. \nSuspendisse potenti. Vestibulum ut iaculis elit, sit amet pulvinar enim. \nVivamus fringilla vitae eros sit amet congue. \nDuis posuere euismod quam et porttitor. Donec facilisis eget massa quis laoreet. \nMaecenas tristique lectus ut venenatis iaculis.\nQuisque scelerisque vehicula mattis..";
	HTMLReport Report1(text, "report.html"); // Product
	CreateReport(Report1);
	Report1.Print();

	getline(cin, text);
	SimpleReport Report2(text, "report.txt"); // Product
	CreateReport(Report2);
	Report2.Print();

	return EXIT_SUCCESS;
}
