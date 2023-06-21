// Day11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Day11.h"
#include <vector>
using namespace std;//is this good?

enum Superpower
{
    Money, Strength, Screaming, Telepathy, Invisibility
};

//forward declaration
void Print(Superpower pow);

int main()
{
    Superpower power = Superpower::Screaming;
    Print(power);
    //std -- standard namespace
    //:: -- scope resolution operator
    //<< -- insertion operator
    std::cout << "Hello Gotham!\n" << 5 << "\n";
    //printf()

    //char are 1 byte
    //wchar are 2 bytes
    char best[] = "Batman";//adds a \0 (null terminator)
    char meh[] = { 'A','q','u','a','m','a','n', '\0'};
    cout << best << "\n" << meh << "\n";

    for (size_t i = 0; i < sizeof(best)/sizeof(char); i++)
    {
        cout << best[i] << " ";
    }
    cout << "\n";

    //seed the random # generator
    srand(time(NULL));
    // % - modulus operator. gives the remainder.
    int random = rand();//0-RAND_MAX (32767)
    random = rand() % 101;//0-100

    //templates
    vector<int> scores;//stack instance
    scores.push_back(rand());
    scores.push_back(rand());
    scores.push_back(rand());
    scores.push_back(rand());
    scores.push_back(rand());
    for (size_t i = 0; i < scores.size(); i++)
    {
        cout << scores[i] << "\n";
    }
    cout << "Range based\n";
    //auto == var
    for (auto score : scores)
    {

    }
    return 0;
}

void Print(Superpower pow)
{
    switch (pow)
    {
    case Money:
        cout << "Money\n";
        break;
    case Strength:
        break;
    case Screaming:
        break;
    case Telepathy:
        break;
    case Invisibility:
        break;
    default:
        break;
    }
}