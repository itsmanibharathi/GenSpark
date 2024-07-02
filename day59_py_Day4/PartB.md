# Part B

[1) merge-the-tools](https://www.hackerrank.com/challenges/merge-the-tools/problem?isFullScreen=true)

```
def split_by_count(string, count):
    return [string[i:i + count] for i in range(0, len(string), count)]

def merge_the_tools(string, k):
    for sub in split_by_count(string, k):
        result = ''
        for j in sub:
            if j not in result:
                result += j
        print(result)
        
if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)

```


[2) py-if-else](https://www.hackerrank.com/challenges/py-if-else/problem?isFullScreen=true)

```
#!/bin/python3

import math
import os
import random
import re
import sys

if __name__ == '__main__':
    n = int(input().strip())
    if(n%2 ==0):
      if(n in range(2,5)):
        print("Not Weird")
      elif(n in range(6,21)):
        print("Weird")
      else:
        print("Not Weird")
    else:
      print("Weird")
```

[3) python-arithmetic-operators](https://www.hackerrank.com/challenges/python-arithmetic-operators/problem?isFullScreen=true)

```
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a+b)
    print(a-b)
    print(a*b)
```

[4) python-division ](https://www.hackerrank.com/challenges/python-division/problem)

```
if __name__ == '__main__':
    a = float(input())
    b = float(input())
    print(a//b)
    print(a/b)

```

[5) python-loops](https://www.hackerrank.com/challenges/python-loops/problem?isFullScreen=true)

```
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
      print(i*i)
```

[6) Python-print ](https://www.hackerrank.com/challenges/python-print/problem?isFullScreen=true)

```
if __name__ == '__main__':
    n = int(input())
    for i in range(1,n+1):
      print(i, end="")
```
[7) list-comprehensions ](https://www.hackerrank.com/challenges/list-comprehensions/problem?isFullScreen=true)

```
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    result = []
    for xi in range(0,x+1):
      for yi in range(0,y+1):
        for zi in range(0,z+1):
          sum = xi+yi+zi
          if(sum != n):
            result.append([xi,yi,zi])
    
    print(result)
          
```
[8) find-second-maximum-number-in-a-list](https://www.hackerrank.com/challenges/find-second-maximum-number-in-a-list/problem?isFullScreen=true)

```
if __name__ == '__main__':
    n = int(input())
    arr = map(int, input().split())
    arr = list(arr)
    print(sorted(set(arr), reverse=True)[1])
```
[9) Company Logo](https://www.hackerrank.com/challenges/most-commons/problem?isFullScreen=true)

```
#!/bin/python3

import math
import os
import random
import re
import sys
from collections import Counter

if __name__ == '__main__':
    s = input()
    s = Counter(s)
    s = [(i, j) for i, j in s.items()]
    s = sorted(s, key=lambda x: (-x[1], x[0]))
    for i in s[:3]:
        print(f"{i[0]} {i[1]}")
```

[10) Leap year or not](https://www.hackerrank.com/challenges/write-a-function/problem?isFullScreen=true)

```
def is_leap(year):
    leap = False
    if year % 400 == 0 and year %100 == 0:
      leap = True
    elif year %4 ==0 and year % 100 != 0:
      leap = True
    return leap

year = int(input())
print(is_leap(year))
```
