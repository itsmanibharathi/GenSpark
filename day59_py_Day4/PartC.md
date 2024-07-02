# Part C

[1) longest-substring-without-repeating-characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/)

```
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        max_len = 0
        start = 0
        seen = {}
        for i, char in enumerate(s):
            if char in seen:
                start = max(start, seen[char] + 1)
            seen[char] = i
            max_len = max(max_len, i - start + 1)
        return max_len
```

[2) zigzag-conversion](https://leetcode.com/problems/zigzag-conversion/)

```
class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if(numRows  < 2):
            return s
        arr = ['' for i in range(numRows)]
        direction = 'down'
        row = 0
        for i in s:
            arr[row] += i
            if row == numRows-1:
                direction = 'up'
            elif row == 0:
                direction = 'down'
            if(direction == 'down'):
                row += 1
            else:
                row -= 1
        return(''.join(arr))
```

[3) 3sum-closest](https://leetcode.com/problems/3sum-closest/)

```
class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:

        n=len(nums)
        nums.sort()
        diff=20001
        val=0
        for i in range(n):
            a=i+1
            b=n-1
            while(a<b):
                sums=nums[i]+nums[a]+nums[b]
                kk=abs(sums-target)
                if(kk<diff):
                    diff=kk
                    val=sums
                if(sums==target):
                    return target
                elif(sums<target):
                    a+=1
                else:
                    b-=1
        return val
```

[4) Generate-parentheses](https://leetcode.com/problems/generate-parentheses/)

```
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        result = []
        self.Parenthesis(result,"",n,n)
        return result

    def Parenthesis(self,result,current,left,right):
        if left == 0 and right == 0:
            result.append(current)
        if left > 0:
            self.Parenthesis(result, current + "(", left - 1, right)
        if left < right:
            self.Parenthesis(result, current + ")", left, right - 1)
```

[5) multiply-strings](https://leetcode.com/problems/multiply-strings/)

```
class Solution:
    def multiply(self, num1: str, num2: str) -> str:
        n1 = int(num1)
        n2 = int(num2)
        return str(n1*n2)

```

[6) group-anagrams](https://leetcode.com/problems/group-anagrams/)

```
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        dd = defaultdict(list)
        for word in strs:
            sword = ''.join(sorted(word))
            dd[sword].append(word)

        return list(dd.values())
```

[7) Jump-game](https://leetcode.com/problems/jump-game/)

```
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        gap = 0
        for n in nums:
            if gap < 0:
                return False
            elif n> gap:
                gap =n
            gap -= 1
        return True

```

[8) Unique-paths](https://leetcode.com/problems/unique-paths/)

```
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        def move(i,j):
            if i==0 and j==0:
                return 1
            if i<0 or j<0:
                return 0
            up=move(i-1,j)
            left=move(i,j-1)
            return up+left
        return move(m-1,n-1)

```

[9) text-justification ](https://leetcode.com/problems/text-justification/description/)

```
class Solution:
    def fullJustify(self, words: List[str], maxWidth: int) -> List[str]:
        result = []
        line =[]
        width = 0

        for w in words:
            if width + len(w)+ len(line) > maxWidth:
                for i in range(maxWidth - width):
                    line[i % (len(line) - 1 or 1)] += ' '
                result.append(''.join(line))
                line = []
                width = 0
            line.append(w)
            width +=len(w)

        result.append(' '.join(line).ljust(maxWidth))
        return result 

```