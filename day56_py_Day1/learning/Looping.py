# Loopinges
# 1. For Loop

fruits = ["apple", "banana", "cherry"]

for x in fruits:
    print(x)
# or
for i in range(len(fruits)):
    print(fruits[i])

# Nested Loop
adj = ["red", "big", "tasty"]

for x in adj:
    for y in fruits:
        print(x,",", y)


# 2. While Loop
i = 0
while i < len(fruits):
    print(fruits[i])
    i += 1

# Python does not have a do while loop