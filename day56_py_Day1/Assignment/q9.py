from itertools import permutations

# 9) Find All Permutations of a given string
def find_permutations(string):
    perms = [''.join(p) for p in permutations(string)]
    return perms

string = input("Enter a string: ")
permutations = find_permutations(string)
print(permutations)


