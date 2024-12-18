#include <bits/stdc++.h>


using namespace std;

char a[200][200];

int main () {
    // FILE *inp = fopen("sample.txt", "r")

    ifstream inp("sample.txt");
    for(int i = 0; i < 10; ++i){
        for(int j = 0; j < 10; ++j) {
            inp >> a[i][j];
        }
    }
    
    
    
    
    
    inp.close();
    inp.open("input.txt");
    inp >> a;
    cout << a;
}