#include <bits/stdc++.h>


using namespace std;

char a[200][200];
int b[200][200];
bool dp[200][200];
int row, col;
int dx[] = {1, 0, -1, 0};
int dy[] = {0, -1, 0, 1};

int solve(ifstream &inp,int R, int C) {
    row = R;
    col = C;
    int score_1 = 0;
    int score_2 = 0;
    for(int i = 0; i < row; ++i){
        for(int j = 0; j < col; ++j) {
            inp >> a[i][j];
        }
    }
    int region = 0;
    memset(b, 0, sizeof(b));
    memset(dp, false, sizeof(dp));
    
    for(int i = 0; i < row; ++i) {
        for(int j = 0; j < col; ++j) {
            if (dp[i][j] == false) {
                dp[i][j] = true;
                region ++;
                char C = a[i][j];
                b[i][j] = region;
                queue<pair<int, int>> q;
                q.push({i, j});
                int area = 0;
                int per = 0;
                int sides = 0;
                map<pair<int, int>, int> mp;
                
                while (!q.empty()){
                    auto [x, y] = q.front();
                    q.pop();
                    b[x][y] = region;
                    area++;
                    for(int k = 0; k < 4; ++k) {
                        int nx = x + dx[k];
                        int ny = y + dy[k];
                        if (nx >= 0 && nx < row && ny >= 0 && ny < col && a[nx][ny] == C) {
                            if (dp[nx][ny] == false) {
                                dp[nx][ny] = true;
                                
                                q.push({nx, ny});
                            }
                        } else {
                            mp[{x, y}] |= (1<<k);
                            mp[{nx, ny}] |= (1<<k);
                            per++;
                        }
                    }
                }
                for (auto v : mp) {
                    int tmp = __builtin_popcount(v.second);
                    
                    if (tmp <= 1 || v.second == 5 || v.second == 10) {
                        continue;
                    }

                    // if (tmp == 2) {
                    //     sides ++;
                    // } else if (tmp == 3) {
                    //     sides += 2;
                    // } else if (tmp == 4) {
                    //     sides += 4;
                    // }
                    sides += (1<<(tmp - 2)); // replaced with this
                    auto [x, y] = v.first;
                    if (a[x][y] != C) {
                        continue;
                    }
                    for (int i = 0; i < 4; ++i) {
                        for(int j = i + 1; j < 4; ++j) {
                            if (((i + j) % 2 == 1) && v.second & (1<<i) && v.second & (1<<j)) {
                                int mx = x + dx[i] + dx[j];
                                int my = y + dy[i] + dy[j];
                                if (mx >= 0 && mx < row && my >= 0 && my < col && b[mx][my] == region) {
                                    sides--;
                                }
                            }
                        }
                    
                    }
                }
                
                score_2 += area * sides;
                score_1 += area * per;

            }
        }
    }
    
    
    cout << score_1 << " " << score_2 << endl;
    return score_2;
}

int main () {
    ifstream inp("sample.txt");
    // solve(inp, 6, 6);
    
    inp.close();
    inp.open("input.txt");
    solve(inp, 140, 140);
}