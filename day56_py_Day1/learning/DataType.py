# datatype

# 1. Text Type:	str

data = "Hello, World!"
print(data)
print(type(data))


# 2. Numeric Types:	int, float, complex
x = 1    # int
print(x)
print(type(x)) 
y = 2.8  # float
print(y)
print(type(y))

z = 1-3j   # complex
print(z)
print(type(z))

print(f"real : {z.real}")
print(f"imaginary : {z.imag}")


# 3. Sequence Types:	list, tuple

# List changeable , ordered and allow duplicate values

list = ["apple", "banana", "cherry"]
list[1] = "blackcurrant"

list.append("apple")
print(list) # ['apple', 'blackcurrant', 'cherry', 'apple']

# Slicing [start:stop:step]
print(list[3:]) # ['apple']

# index
print(list.index("cherry")) # 2


# Tuple unchangeable, ordered and allow duplicate values
tuple = ("apple", "banana", "cherry")
# tuple[1] = "blackcurrant" # TypeError: 'tuple' object does not support item assignment
print(tuple) # ('apple', 'banana', 'cherry')

# 4. Mapping Type:	dict
#dict unordered, changeable, indexed, no duplicate values
dict = {"name" : "John", "age" : 36}
dict["age"] = 40
print(dict) # {'name': 'John', 'age': 40}

print(dict.keys()) # dict_keys(['name', 'age'])

print(dict.values()) # dict_values(['John', 40])


# 5. Set Types:	set
#set unordered, unindexed, no duplicate values
set = {"apple", "banana", "cherry"}
set.add("apple")
print(set) # {'banana', 'apple', 'cherry'}


# 6. Boolean Type:	bool
#bool True or False
bool = True
print(bool) # True

# 7. Binary Types:	bytes, bytearray, memoryview

#bytes immutable sequence of integers in the range 0 <= x < 256

x = b"Hello"
print(x) # b'Hello'