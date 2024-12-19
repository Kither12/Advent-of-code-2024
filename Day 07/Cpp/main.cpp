#include <bits/stdc++.h>

using namespace std;
#define ll long long


ll solve_1(ifstream &inp) {
    ll answer = 0;
    ll total;
    char c;
    while (inp >> total >> c) {
        string s;
        getline(inp, s);
        
        stringstream ss(s);
        vector<ll> ar;
        ll x;
        while (ss >> x) {
            ar.push_back(x);
        }
        
        for(int mask = 0; mask < (1<<(ar.size() - 1)); ++mask){
            ll S = ar[0];
            for(int i = 0; i < ar.size() - 1; ++i) {
                if (mask & (1<<i)) {
                    S += ar[i + 1];
                } else S *= ar[i + 1];
            }
            if (S == total){
                answer += total;
                break;
            }
        }
    }
    return answer;
}

ll solve_2(ifstream &inp) {
    ll answer = 0;
    ll total;
    char c;
    while (inp >> total >> c) {
        string s;
        getline(inp, s);
        
        stringstream ss(s);
        vector<ll> ar;
        ll x;
        while (ss >> x) {
            ar.push_back(x);
        }
        
        for (int mask = 0; mask < int(pow(3, ar.size() - 1)); ++mask) {
            int tmp = mask;
            ll S = ar[0];
            for(int i = 0; i < ar.size() - 1; ++i) {
                if (tmp % 3 == 0) {
                    S += ar[i + 1];
                } else if (tmp % 3 == 1) {
                    S *= ar[i + 1];
                } else {
                    S = S * int(pow(10, to_string(ar[i + 1]).size())) + ar[i + 1];
                }
                tmp /= 3;
            }
            if (S == total){
                answer += total;
                break;
            }
        }
    }
    return answer;
}

int main() {
    ifstream inp("sample.txt", ios::in);
    ifstream inp2("sample.txt", ios::in);
    
    cout << solve_1(inp) << '\n';
    cout << solve_2(inp2) << '\n';
    inp.close();
    inp2.close();
    
    inp.open("input.txt");
    inp2.open("input.txt");
    cout << solve_1(inp) << '\n';
    cout << solve_2(inp2) << '\n';

    inp.close();
}