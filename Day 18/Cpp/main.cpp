#include <bits/stdc++.h>

using namespace std;    

char dp[80][80];
int f[80][80];
int dx[] = {1, 0, -1, 0};
int dy[] = {0, 1, 0, -1};


int solve_1(vector<pair<int, int>> &a, int row, int col, int question){
    memset(dp, '.', sizeof(dp));
    memset(f, 0, sizeof(f));    
    for (int i = 0; i < question; ++i){
        dp[a[i].first][a[i].second] = 'X';
    }
    
    queue<pair<int, int>> q;
    
    q.push({0, 0}); 
    dp[0][0] = 'O';
    f[0][0] = 0;
    
    while (!q.empty()) {
        auto [x, y] = q.front();
        
        q.pop();
        if (x == row - 1 && y == col - 1){
            
            return f[x][y];
        }
        for (int i = 0; i < 4; ++i){
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (nx < 0 || nx >= row || ny < 0 || ny >= col || dp[nx][ny] != '.'){
                continue;
            }
            if (dp[nx][ny] == '.'){
                dp[nx][ny] = 'O';
                f[nx][ny] = f[x][y] + 1;
                q.push({nx, ny});
            }
        }
    }
    return -1;
}



pair<int, int> solve_2(vector<pair<int, int>> &a, int row, int col){
    memset(dp, '.', sizeof(dp));
    
    int head = 0;
    while (true) {
        dp[a[head].first][a[head].second] = 'X';
        memset(f, 0, sizeof(f));        
        queue<pair<int, int>> q;
        
        q.push({0, 0}); 
        dp[0][0] = 'O';
        f[0][0] = 0;
        bool flag = false;
        while (!q.empty()) {
            auto [x, y] = q.front();
            
            q.pop();
            if (x == row - 1 && y == col - 1){
                flag = true;
                break;
            }
            for (int i = 0; i < 4; ++i){
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx < 0 || nx >= row || ny < 0 || ny >= col || dp[nx][ny] == 'X'){
                    continue;
                }
                
                if (f[nx][ny] == 0) {
                    f[nx][ny] = f[x][y] + 1;
                    q.push({nx, ny});
                }
                
            }
        }
        if (flag) {
            ++head;
            continue;
        }
        return {a[head].first, a[head].second};
    }
    
    
    
    return {-1, -1};
}

int main() {
    // ios_base::sync_with_stdio(false);
    // cin.tie(NULL);
    int x, y;
    char c;
    vector<pair<int, int>> ar;
    
    // freopen("sample.txt", "r", stdin);
    // while (cin >> y >> c >> x){
    //     ar.push_back({x, y});
    // }
    // cout << solve_1(ar, 7, 7, 12) << '\n';
    // auto ans = solve_2(ar, 7, 7);
    // cout << ans.second << ',' << ans.first << '\n';

    freopen("input.txt", "r", stdin);
    ar.clear();
    while (cin >> y >> c >> x){
        ar.push_back({x, y});
    }
    cout << solve_1(ar, 71, 71, 1024) << '\n';
    auto ans = solve_2(ar, 71, 71);
    cout << ans.second << ',' << ans.first << '\n';
    
    return 0;
}