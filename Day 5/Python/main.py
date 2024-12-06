
with open("input.txt") as f:
    lines = f.readlines()




id = lines.index("\n")
lines = [line.strip() for line in lines]
# print(lines)



def solve_1(lines, id):
    ans = 0
    for updates in lines[id + 1:]:
        nums = list(map(int, updates.split(',')))
        hash_map = {}
        for i, x in enumerate(nums):
            hash_map[x] = i
        flag = True
        for rules in lines[:id]:
            a, b = map(int, rules.split('|'))
            if a not in hash_map or b not in hash_map:
                continue
            if hash_map[a] > hash_map[b]:
                flag = False
                break
        if flag:
            ans += nums[len(nums) // 2]
    return ans


import queue
def get_topological_order(edges, n, graph):
    deg = [0 for i in range(100)]
    for a, b in edges:
        deg[b] += 1
        
    q = queue.Queue()
    for node in range(100):
        if deg[node] == 0:
            q.put(node)
    
    topo = []
    while q.qsize():
        x = q.get()
        topo.append(x)
        for y in graph[x]:
            deg[y] -= 1
            if deg[y] == 0:
                q.put(y)
    return topo[::-1]

def solve_2(lines, id):
    edges = []
    n = 0
    list_nodes = [[] for i in range(100)]
    for rules in lines[:id]:
        a, b = map(int, rules.split('|'))
        n = max(n, a, b)
        list_nodes[a].append(b)
        edges.append((a, b))
    
    topo = get_topological_order(edges, n, list_nodes)
    print(topo)
    ans = 0
    for updates in lines[id + 1:]:
        nums = list(map(int, updates.split(',')))
        
        flag = True
        hash_map = {}
        for i, x in enumerate(nums):
            hash_map[x] = i
        flag = True
        for rules in lines[:id]:
            a, b = map(int, rules.split('|'))
            if a not in hash_map or b not in hash_map:
                continue
            if hash_map[a] > hash_map[b]:
                flag = False
                break
        if flag == False:
            nums.sort(key=lambda x: topo.index(x))
            ans += nums[len(nums) // 2]
    return ans



print("Answer of Day 5 part 1:", solve_1(lines, id))
print("Answer of Day 5 part 2:", solve_2(lines, id))


