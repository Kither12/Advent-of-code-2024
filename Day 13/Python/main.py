import re


def solve(d):
    a, b, c, d, x, y = map(int, re.findall(r"\d+", d))
    z = ((x + p) * (b - 3 * d) - (y + p) * (a - 3 * c)) / (b * c - a * d)
    return z * (not z % 1)


data = open("input.txt").read().split("\n\n")
for p in 0, 1e13:
    print(int(sum(map(solve, data))))
