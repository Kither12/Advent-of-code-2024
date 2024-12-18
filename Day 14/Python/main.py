
def parse_input(ar):
    a, b = [], []
    for x in ar:
        pos, val = x.split()
        x, y = map(int, pos.replace('p=','').split(","))
        dx, dy = map(int, val.replace('v=','').split(","))
        a.append((x, y))
        b.append((dx, dy))
    return a, b

from math import prod


def solve_1(ar, row, col):
    pos, dir = parse_input(ar)
    
    mid_row = row // 2
    mid_col = col // 2
    bag = [0 for _ in range(4)]
    for i in range(len(pos)):
        x, y = pos[i]
        dx, dy = dir[i]
        nx = (x + dx * 100) % col
        ny = (y + dy * 100) % row
        if nx == mid_col or ny == mid_row:
            continue
        bag[(nx < mid_col) * 2 + (ny < mid_row) ] += 1
    return prod(bag)


def solve_2(ar, row, col):
    pos, dir = parse_input(ar)
    
    mid_row = row // 2
    mid_col = col // 2
    bag = [0 for _ in range(4)]
    
    for time_elapse in range(1, 1000000):
        ar = [[0 for _ in range(row)] for _ in range(col)]
        next_set = set()
        matching = set()
        for i in range(len(pos)):
            x, y = pos[i]
            dx, dy = dir[i]
            nx = (x + dx * time_elapse) % col
            ny = (y + dy * time_elapse) % row
            ar[nx][ny] += 1
            
            # Idea was to check if there are group of robots are bundled together.
            # This part of the check was taken from https://github.com/pj0620/AdventOfCode/blob/main/2024/day14/day14_p2.py#L39
            if (nx, ny) in next_set:
                matching.add((nx, ny))
            for dx in [-1, 0, 1]:
                for dy in [-1, 0, 1]:
                    next_set.add((nx + dx, ny + dy))
        if len(matching) > 256:
            open('output.txt', 'w').close()
            for i in range(col):
                for j in range(row):
                    print(ar[i][j] if ar[i][j] > 0 else '.', end = '', file=open('output.txt', 'a'))
                print(file=open('output.txt', 'a'))
            input(f'Time Elapse: {time_elapse}, Ctrl + C to quit')
    return prod(bag)


with open("sample.txt") as f:
    ar = f.readlines()
    print("Sample part 1 day 14:", solve_1(ar, 7, 11))
    
    
with open("input.txt") as f:
    ar = f.readlines()
    print("Solution part 1 day 14:", solve_1(ar,103, 101))
    print(f"Solution Part 2 Day 14: {solve_2(ar,103, 101)}")