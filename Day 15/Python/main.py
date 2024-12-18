
move_dict = {
    '^': (-1, 0),
    'v': (1, 0),
    '<': (0, -1),
    '>': (0, 1)
}

def new_map(ar): 
    ans = ['' for i in range(len(ar))]
    for i in range(len(ar)):
        for j in range(len(ar[0])):
            if ar[i][j] == '#':
                ans[i] += '##'
            elif ar[i][j] == '.':
                ans[i] += '..'
            elif ar[i][j] == 'O':
                ans[i] += '[]'
            else:
                ans[i] += '@.'
    return ans

def solve_1(ar, q):
    def vacate(ar, x, y, dir):
        dx, dy = dir
        nx = x + dx
        ny = y + dy
        if ar[x][y] in '@O':
            vacate(ar, nx, ny, dir)
            if ar[nx][ny] == '.':
                ar[nx][ny] = ar[x][y]
                ar[x][y] = '.'
        return 
    x, y = 0, 0
    for i in range(len(ar)):
        for j in range(len(ar[0])):
            if ar[i][j] == '@':
                x, y = i, j
    
    for move in q:
        dir = move_dict[move]
        vacate(ar, x, y, dir)
        if (ar[x][y] == '.'):
            x += dir[0]
            y += dir[1]
    score = 0
    for i in range(len(ar)):
        for j in range(len(ar[0])):
            if (ar[i][j] == 'O'):
                score += 100 * i + j
    return score
    
    
def solve_2(ar, q):
    def vacate(ar, p, dir):
        
        dx, dy = dir    
        if len(p) == 1:    
            x, y = p[0]
            if ar[x][y] in '[]':
                if ar[x][y] == ']':
                    vacate(ar, [(x, y), (x, y - 1)], dir)
                else:
                    vacate(ar, [(x, y), (x, y + 1)], dir)
                return       
            
            if ar[x][y] in '#.':
                return
            nx = x + dx
            ny = y + dy
            vacate(ar, [(nx, ny)], dir)
            if ar[nx][ny] == '.':
                ar[nx][ny] = ar[x][y]
                ar[x][y] = '.'
                    
        else:
            new_p = [(u + dx, v + dy) for u, v in p]
            for i in range(len(new_p)):
                nx, ny = new_p[i]    
                vacate(ar, [(nx, ny)], dir)
            if all([ar[nx][ny] == '.' for nx, ny in new_p]):
                for x, y in p:
                    ar[x + dx][y + dy] = ar[x][y] 
                    ar[x][y] = '.'
        return
    
    
    
    x, y = 0, 0
    for i in range(len(ar)):
        for j in range(len(ar[0])):
            if ar[i][j] == '@':
                x, y = i, j
    
    
    for move in q:
        dir = move_dict[move]
        print(move)
        if move == '>':
            col = y
            while ar[x][col] in '@[]':
                col += 1
            if ar[x][col] == '.':
                for i in range(col, y, -1):
                    ar[x][i] = ar[x][i - 1]
                ar[x][y] = '.'
                x += dir[0]
                y += dir[1]
            for tmp in ar:
                print(''.join(tmp)) 
            continue
        elif move == '<':
            col = y
            
            while ar[x][col] in '@[]':
                col -= 1
            if ar[x][col] == '.':
                for i in range(col, y):
                    ar[x][i] = ar[x][i + 1]
                ar[x][y] = '.'
                x += dir[0]
                y += dir[1]
            for tmp in ar:
                print(''.join(tmp))
            continue
        vacate(ar, [(x, y)], dir)
        if (ar[x][y] == '.'):
            x += dir[0]
            y += dir[1]
        for tmp in ar:
            print(''.join(tmp))
    score = 0
    for i in range(len(ar)):    
        for j in range(len(ar[0])):
            if (ar[i][j] == '['):
                score += 100 * i + j
    return score

with open("sample.txt") as f:
    ar, q = f.read().split('\n\n')
    ar = list(map(list, ar.split()))
    q = ''.join(q.split())
    br = new_map(ar[::])
    br = list(map(list, br))
    print(f"Sample Part 1 Day 15: {solve_1(ar, q)}")
    print(f"Sample Part 2 Day 15: {solve_2(br, q)}")
    
    

with open("input.txt") as f:
    ar, q = f.read().split('\n\n')
    ar = list(map(list, ar.split()))
    q = ''.join(q.split())
    br = new_map(ar[::])
    br = list(map(list, br))
    # print(f"Solution Part 1 Day 15: {solve_1(ar, q)}")
    # print(f"Solution Part 2 Day 15: {solve_2(br, q)}")