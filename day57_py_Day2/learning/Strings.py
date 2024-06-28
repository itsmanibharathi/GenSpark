# string Manipulation

# capitalize() - Converts the first character to upper case
name = "mani"
print(name.capitalize()) # Mani

# casefold() - Converts string into lower case
name = "MANI"
print(name.casefold()) # mani

# center() - Returns a centered string
name = "mani"
print(name.center(20)) #        mani

# count() - Returns the number of times a specified value occurs in a string
name = "mani"
print(name.count("n")) # 1

# encode() - Returns an encoded version of the string
name = "mani"
print(name.encode()) # b'mani'

# endswith() - Returns true if the string ends with the specified value
name = "mani"
print(name.endswith("i")) # True

# expandtabs() - Sets the tab size of the string
name = "mani\tbharathi"
print(name) # mani    bharathi
print(name.expandtabs(10)) # mani      bharathi

paragraph = "Hello\t welcome \n to \rmy \t world."

print(paragraph.expandtabs(0)) # Hello      welcome

# find() - Searches the string for a specified value and returns the position of where it was found
# find(value, start, end)
name = "mani"
print(name.find("a",0,2)) # 1

# format() - Formats specified values in a string
name = "mani"
print("My name is {}".format(name)) # My name is mani
print("My name is {}, age is {}".format(name,21)) # My name is mani, age is 21
# format_map() - Formats specified values in a string

print("My name is {name}, age is {age} ".format_map({'name':"mani","age":21})) # My name is mani age is 21

# index() - Searches the string for a specified value and returns the position of where it was found
name = "mani"
print(name.index("a")) # 1

# isalnum() - Returns True if all characters in the string are alphanumeric
name = "mani6"
print(name.isalnum()) # True

# isalpha() - Returns True if all characters in the string are in the alphabet
name = "mani"
print(name.isalpha()) # True

# isascii() - Returns True if all characters in the string are ascii characters
print(name.isascii()) # True

# isdecimal() - Returns True if all characters in the string are decimals
name = "123"
print(name.isdecimal()) # True

# isdigit() - Returns True if all characters in the string are digits
name = "1"
print(name.isdigit()) # True

# islower() - Returns True if all characters in the string are in lower case
name = "mani"
print(name.islower()) # True

# isnumeric() - Returns True if all characters in the string are numeric

name = "123"
print(name.isnumeric()) # True


# isprintable() - Returns True if all characters in the string are printable
name = "mani"
print(name.isprintable()) # True

# isspace() - Returns True if all characters in the string are whitespaces
name = " "
print(name.isspace()) # True

#str.removeprefix(prefix, /) - Return a copy of the string with the leading prefix string removed. If the string doesn't start with the prefix string, return a copy of the original string.
name = "mani"
print(name.removeprefix("ma")) # ni

#str.removesuffix(suffix, /) - Return a copy of the string with the trailing suffix string removed. If the string doesn't end with the suffix string, return a copy of the original string.

name = "mani"

# splitlines() - Splits the string at line breaks and returns a list
name = "mani\nbharathi"
print(name.splitlines()) # ['mani', 'bharathi']

# startswith() - Returns true if the string starts with the specified value

print(name.startswith("m")) # True


print(name.removesuffix("ni")) # ma

# split() - Splits the string at the specified separator, and returns a list

name = "mani bharathi"
print(name.split(" ")) # ['mani', 'bharathi']

# splitlines() - Splits the string at line breaks and returns a list
name = "mani\nbharathi"
print(name.splitlines()) # ['mani', 'bharathi']

# join() - Joins the elements of an iterable to the end of the string
name = ["mani","bharathi"]
print(" ".join(name)) # mani bharathi