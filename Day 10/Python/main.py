cnt = 0
bag = set()
dx = [0, 0, 1, -1]
dy = [1, -1, 0, 0]
def dfs(ar, x, y):
    global cnt, bag
    if ar[x][y] == 9:
        bag.add((x, y))
        cnt += 1
        return
    
    for k in range(4):
        nx = x + dx[k]
        ny = y + dy[k]
        if nx >= 0 and nx < len(ar) and ny >= 0 and ny < len(ar[0]) and ar[nx][ny] == ar[x][y] + 1:
            dfs(ar, nx, ny)
            

def solve(ar):
    global cnt, bag 
    row = len(ar)
    col = len(ar[0])
    cnt = 0
    score = 0 
    for i in range(row):
        ar[i] = list(map(int, ar[i]))
    
    for i in range(row):
        for j in range(col):
            
            if ar[i][j] == 0:
                bag = set()
                dfs(ar, i, j)
                score += len(bag)
            
    
    print(cnt, score)
    

with open("sample.txt") as f:
    ar = f.read().splitlines()
    
    ar = list(map(list, ar))
    solve(ar)
    
    
    
with open("input.txt") as f:
    ar = f.read().splitlines()
    
    ar = list(map(list, ar))
    solve(ar)
