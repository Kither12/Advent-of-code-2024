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
            e, f = d[k][j][0], d[k][j][1]
            #               vv choosing 50 due to my input have atmost 50 lines
            for idx in range(-50, 50):
                nx, ny = e + idx * dx, f + idx * dy
                if 0 <= nx < len(arr) and 0 <= ny < len(arr[0]):
                    bag.add((nx, ny))
                
            
                
                
print(len(bag))
            
            
            