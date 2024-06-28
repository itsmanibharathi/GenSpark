# 1) Longest Substring Without Repeating Characters. 
# That is in a given string find the longest substring that does not contain any character twice.

def logest_substring(string):
    max_len = 0
    start = 0
    seen = {}
    for i, char in enumerate(string):
        if char in seen:
            start = max(start, seen[char] + 1)
        seen[char] = i
        max_len = max(max_len, i - start + 1)
    return max_len


print(logest_substring("aabca"))






