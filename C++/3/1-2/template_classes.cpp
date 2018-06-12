#include "template_classes.h"

void make_bigger(int & a)
{
	a *= 10;
}
void make_smaller(int & a)
{
	a /= 10;
}

void forEach(LinkedList & L, funcPtr F)
{
	LinkedList::Link * everyChange = L.getNode();
	for (int i = 0; i < L.get_size(); ++i)
	{
		F(everyChange->data);
		everyChange = everyChange->next;
	}
}
void forEach(BinaryTree & T, funcPtr F)
{
	/*
									ПОШУК ВШИР
	Корінь->черга

	Поки черга не пуста
	1. візьми елемент з початку черги і кинь його дітей в кінець черги
	2. забери лемент з початку черги
	*/

	queue<BinaryTree::Node *> Element;
	Element.push(T.getNode());
	
	while (!Element.empty())
	{
		BinaryTree::Node* tempNode = Element.front();

		if (tempNode->left)
		{
			Element.push((tempNode->left));
		}
		if (tempNode->right)
		{
			Element.push((tempNode->right));
		}

		Element.pop();
		F( tempNode->data);
	}		
}