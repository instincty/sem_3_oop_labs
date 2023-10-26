#include <iostream>
#define PI 3.141592

using namespace std;

class volumeCalculation
{
public:
    double rectVol(double a, double b, double c)
    {
        return a * b * c;
    }
    double pyramidVol(double base, double height)
    {
        return base * height * (1.0/3);
    }
    double sphereVolR(double radius)
    {
        return (4.0/3) * PI * radius * radius * radius;
    }
};

int main()
{
    char fType;
    volumeCalculation vol;
    cout << "Choose a figure (r - rectangle, p - pyramid, s - sphere): ";
    cin >> fType;
    fType = toupper(fType);
    switch (fType)
    {
    case 'R':
        double a, b, c;
        cout << "Enter a, b, c:\n";
        cin >> a;
        cin >> b;
        cin >> c;
        cout << "Rectangle volume = " << vol.rectVol(a, b, c);
        break;
    case 'P':
        double base, height;
        cout << "Enter base, height:\n";
        cin >> base;
        cin >> height;
        cout << "Pyramid volume = " << vol.pyramidVol(base, height);
        break;
    case 'S':
        double r;
        cout << "Enter radius:\n";
        cin >> r;
        cout << "Sphere radius = " << vol.sphereVolR(r);
        break;
    default:
        cout << "Wrong input!" << endl;
        return 0;
    }
    return 0;
}
