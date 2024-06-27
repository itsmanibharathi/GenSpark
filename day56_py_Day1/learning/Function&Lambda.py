# function or Methods

def add(a, b):
    return a + b

print(add(10, 3)) # 13


# Lambda Function
# A lambda function is a small anonymous function.
# lambda arguments: expression
add = lambda a, b: a + b
print(add(10, 3)) # 13


def myfunc(n):
  return lambda a : a - n

mydoubler = myfunc(2)

print(mydoubler(1))
