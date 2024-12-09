import re

matches = re.findall(
    r"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)",
    open("input.txt").read(),
)
res = 0
flag = True
for match in matches:
    if match == "do()":
        flag = True
        continue
    if match == "don't()":
        flag = False
        continue
    if flag:
        x, y = map(int, match[4:-1].split(","))
        res += x * y
print(res)
