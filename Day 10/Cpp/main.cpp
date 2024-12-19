#include <bits/stdc++.h>

using namespace std;

int a[100][100];
bool dp[100][100];

int cnt = 0;
int dx[] = {0, 0, 1, -1};
int dy[] = {1, -1, 0, 0};
int row, col;
int cnter = 0;

void dfs(int x, int y) {
    if (a[x][y] == 9) {
        ++cnt;
        return;
    }
    for(int k = 0; k < 4; ++k) {
        int nx = x + dx[k];
        int ny = y + dy[k];
        if (nx >= 0 && nx < row && ny >= 0 && ny < col && (a[nx][ny] == a[x][y] + 1) && !dp[nx][ny]) {
            dp[nx][ny] = true;
            
            dfs(nx, ny);
            if (a[nx][ny] != 9) {
                dp[nx][ny] = false;
            }
        }
    }
}


void dfs2(int x, int y) {
    if (a[x][y] == 9) {
        ++cnter;
        return;
    }
    for(int k = 0; k < 4; ++k) {
        int nx = x + dx[k];
        int ny = y + dy[k];
        if (nx >= 0 && nx < row && ny >= 0 && ny < col && (a[nx][ny] == a[x][y] + 1) && !dp[nx][ny]) {
            dp[nx][ny] = true;
            dfs2(nx, ny);
            dp[nx][ny] = false;
        }
    }
}


int solve_1(ifstream &inp, int R, int C) {
    memset(dp, false, sizeof(dp));
    memset(a, 0, sizeof(a));
    row = R;
    col = C;
    for(int i = 0; i < row; ++ i){
        for(int j = 0; j < col; ++ j) {
            char c;
            inp >> c;
            a[i][j] = c - '0';
        }
    }
    
    cnt = 0;
    for(int i = 0; i < row; ++ i) {
        for(int j = 0; j < col; ++ j) {
            
            if (a[i][j] == 0){
                memset(dp, false, sizeof(dp));
                dp[i][j] = true;
                dfs(i, j);
                dp[i][j] = false;
                
            }
            
        }
        
    }
    return cnt;
}

int solve_2(ifstream &inp, int R, int C) {
    memset(dp, false, sizeof(dp));
    memset(a, 0, sizeof(a));
    row = R;
    col = C;
    for(int i = 0; i < row; ++ i){
        for(int j = 0; j < col; ++ j) {
            char c;
            inp >> c;
            a[i][j] = c - '0';
        }
    }
    
    cnter = 0;
    for(int i = 0; i < row; ++ i) {
        for(int j = 0; j < col; ++ j) {
        
            if (a[i][j] == 0){
                dp[i][j] = true;
                dfs2(i, j);
                dp[i][j] = false;   
            }
            
        }
        
        
    }
    return cnter;
}

int main() {
    ifstream inp("sample.txt");
    ifstream inp2("sample.txt");

    cout << solve_1(inp, 8, 8) << '\n';
    cout << solve_2(inp2, 8, 8) << '\n';
    inp.close();
    inp2.close();
    inp.open("input.txt"); 
    inp2.open("input.txt");
    cout << solve_1(inp, 54, 54) << '\n';
    cout << solve_2(inp2, 54, 54) << '\n';
}