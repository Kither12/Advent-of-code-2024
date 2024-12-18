



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


dx = [-1, 0, 1, 0]
dy = [0, 1, 0, -1]

def solve_1(ar):
    




with open("sample.txt") as f:
    ar = f.read().splitlines()
    ar = list(map(list, ar))
    # print(ar)
    print("Sample part 1 day 14:", solve_1(ar))
    
    
with open("input.txt") as f:
    ar = f.readlines()
    # print("Solution part 1 day 14:", solve_1(ar,103, 101))
    