a =10 # a is 10

a,b = 10,20 # a is 10 and b is 20

a=b=10 # a , b are 10

data=[1,2,3,4,5] 
# unpacking
a,b,c,d,e = data # a is 1, b is 2, c is 3, d is 4, e is 5

# swapping
a,b = b,a # a is 20, b is 10

# Global and Local Variables
x = "global"

def foo():
    x = "local"
    print("x inside foo:", x)

foo()

print("x outside foo:", x)


# Global Keyword
x = "global"

def foo():
    global x
    x= x * 2
    print(x)
foo()

print(x)

# Deleting Variables
x = "global"

def foo():
    global x
    del x
    x = "local"
    print(x)

foo()

print(x)




