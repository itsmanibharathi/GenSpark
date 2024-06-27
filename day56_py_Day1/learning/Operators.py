# Operators in Python

# Arithmetic Operators
# +, -, *, /, %, //, **

print(10 + 3) # 13
print(10 - 3) # 7

# Comparison Operators
# ==, !=, >, <, >=, <=

print(10 == 3) # False

# Logical Operators
# and, or, not

print(10 > 3 and 10 < 20) # True\
print(not 10 > 3) # False
print(10 > 3 or 10 < 20) # True


# Assignment Operators

x = 5

#  {operation}=value  is same as x = x {operation} value
x += 3


print(x) # 8

# Identity Operators

x = ["apple", "banana"]
y = ["apple", "banana"]
z = x

print(x is y) # False
print(x is z) # True
print(x is not y) # True

# Membership Operators

print("banana" in x) # True
print("banana" not in x) # False


# Bitwise Operators

# AND &, OR |, XOR ^, NOT ~, Left Shift <<, Right Shift >>

print(5 & 3) # 1

print(5 | 3) # 7

print(5 << 1) # 10
