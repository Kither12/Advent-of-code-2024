from collections import defaultdict
with open("input.txt", "r") as f:
    arr = f.readlines()
    arr = list(map(lambda x: x.strip(), arr))



d = defaultdict(list)
for i in range(len(arr)):
    for j in range(len(arr[i])):
        if arr[i][j] != ".":
            d[arr[i][j]].append((i, j))


bag = set()

for k, v in d.items():
    for i in range(len(v)):
        for j in range(i):
            dx = d[k][i][0] - d[k][j][0]
            dy = d[k][i][1] - d[k][j][1]
            u, t = d[k][i][0] + dx, d[k][i][1] + dy
            bag.add((u, t))
            e, f = d[k][j][0] - dx, d[k][j][1] - dy
            bag.add((e, f))
            
            

bag = set(filter(lambda x: 0 <= x[0] < len(arr) and 0 <= x[1] < len(arr[0]), bag))
print(len(bag))
            