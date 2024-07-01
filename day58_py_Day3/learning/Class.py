# pythion class
from typing import Any


class myNewClass:
    x = 5

p1 = myNewClass()
print(p1.x)

# python class with __init__ method

class Person:
    def __init__(self, name, age): # __init__ method is called when you create a new object
        self.name = name
        self.age = age
    def __repr__(self) -> str: # __repr__ method is called when you use the object in the interpreter
        return f'{self.name} is {self.age} years old.'   
    def __str__(self): # __str__ method is called when you use print() function
        return f'{self.name} is {self.age} years old.----'
    def __format__(self, format_spec: str) -> str: # __format__ method is called when you use format() function
        return f'{self.name} is {self.age} years old.++++'
    # compartion operators methods are: __lt__, __le__, __eq__, __ne__, __gt__, __ge__

    def __lt__(self, other):
        return self.age < other.age
    def __eq__(self, other):
        return self.age == other.age
    
    #  trest value of the object
    def __bool__(self):

        return True
    
    # test value of the object
    def __len__(self):
        return len(self.name)
    
    # get attribute of the object
    def __getattr__(self, name):
        return f'{name} is not found'
    
    def __getattribute__(self, name):
        return f'{name} is found'
    

p1 = Person('John', 36)
print(p1)
print(repr(p1))
print(format(p1))
print(f'{p1}')

# what is the difference between __repr__ and __str__?
# __repr__ is used to print the object in the interpreter
# __str__ is used to print the object when you use print() function


# __lt__ method is used to compare two objects
p2 = Person('Jane', 25)
print(p1 < p2) # False
print(p1 == p2) # False

# __bool__ method is used to test the value of the object

print(bool(p1)) # True if bool method is not defined, it will return True by default

# __len__ method is used to test the value of the object

print(len(p1)) # 4

# __getattr__ method is used to get the attribute of the object

print(p1.age) # 36

print(p1.address) # address is not found







#  laearn get attr , get attribute , set attribute, del attribute, get item, set item, del item, call, len, iter, next, contains, enter, exit, hash, str, format, repr, bool, copy, deepcopy, getstate, setstate, reduce, reduce_ex, new, init, del, get, set, delete

print('-'*20)

import copy

class Example:
    def __new__(cls, *args, **kwargs):
        
        # Create and return a new instance.
        
        print("Creating instance")
        instance = super(Example, cls).__new__(cls)
        return instance

    def __init__(self, value):
        
        # Initialize the instance with a value.
        
        print("Initializing instance")
        self.value = value
        self.items = {}

    def __del__(self):
        
        # Delete the instance.
        
        print("Deleting instance")

    def __getattr__(self, name):
        
        # Called when an attribute is not found.
        
        print(f"Getting attribute '{name}'")
        return f"Attribute '{name}' not found"

    def __getattribute__(self, name):
        
        # Called when any attribute is accessed.
        
        print(f"Accessing attribute '{name}'")
        return super(Example, self).__getattribute__(name)

    def __setattr__(self, name, value):
        
        # Called when an attribute is set.
        
        print(f"Setting attribute '{name}' to '{value}'")
        super(Example, self).__setattr__(name, value)

    def __delattr__(self, name):
        
        # Called when an attribute is deleted.
        
        print(f"Deleting attribute '{name}'")
        super(Example, self).__delattr__(name)

    def __getitem__(self, key):
        
        # Called to get an item using the subscript notation.
        
        print(f"Getting item '{key}'")
        return self.items.get(key, f"Item '{key}' not found")

    def __setitem__(self, key, value):
        
        # Called to set an item using the subscript notation.
        
        print(f"Setting item '{key}' to '{value}'")
        self.items[key] = value

    def __delitem__(self, key):
        
        # Called to delete an item using the subscript notation.
        
        print(f"Deleting item '{key}'")
        del self.items[key]

    def __call__(self, *args, **kwargs):
        
        # Called when the instance is called as a function.
        
        print("Calling instance")
        return f"Called with arguments: {args} and keyword arguments: {kwargs}"

    def __len__(self):
        
        # Called to get the length of the instance.
        
        print("Getting length")
        return len(self.items)

    def __iter__(self):
        
        # Called to create an iterator.
        
        print("Creating iterator")
        self._iter = iter(self.items)
        return self

    def __next__(self):
        
        # Called to get the next item from the iterator.
        
        print("Getting next item")
        return next(self._iter)

    def __contains__(self, item):
        
        # Called to check if an item is in the instance.
        
        print(f"Checking if '{item}' is in items")
        return item in self.items

    def __enter__(self):
        
        # Called when entering a context.
        
        print("Entering context")
        return self

    def __exit__(self, exc_type, exc_val, exc_tb):
        
        # Called when exiting a context.
        
        print("Exiting context")
        return False

    def __hash__(self):
        
        # Called to get the hash of the instance.
        
        print("Getting hash")
        return hash(self.value)

    def __str__(self):
        
        # Called to get the string representation of the instance.
        
        print("Getting string representation")
        return f"Example with value: {self.value}"

    def __format__(self, format_spec):
        
        # Called to format the instance.
        
        print("Formatting instance")
        return format(str(self), format_spec)

    def __repr__(self):
        
        # Called to get the 'official' string representation of the instance.
        
        print("Getting repr")
        return f"Example({self.value!r})"

    def __bool__(self):
        
        # Called to get the boolean representation of the instance.
        
        print("Getting boolean representation")
        return bool(self.value)

    def __copy__(self):
        
        # Called to copy the instance.
        
        print("Copying instance")
        return type(self)(self.value)

    def __deepcopy__(self, memo):
        
        # Called to deep copy the instance.
        
        print("Deep copying instance")
        return type(self)(copy.deepcopy(self.value, memo))

    def __getstate__(self):
        
        # Called to get the state of the instance for pickling.
        
        print("Getting state")
        return self.__dict__

    def __setstate__(self, state):
        
        # Called to set the state of the instance during unpickling.
        
        print("Setting state")
        self.__dict__.update(state)

    def __reduce__(self):
        
        # Called to get the picklable representation of the instance.
        
        print("Reducing instance for pickling")
        return (type(self), (self.value,))

    def __reduce_ex__(self, protocol):
        
        # Called to get the picklable representation of the instance with a protocol.
        
        print(f"Reducing instance for pickling with protocol {protocol}")
        return self.__reduce__()

    # Descriptor methods
    def __get__(self, instance, owner):
        
        # Called to get the value from a descriptor.
        
        print("Getting descriptor value")
        return self.value

    def __set__(self, instance, value):
        
        # Called to set the value of a descriptor.
        
        print("Setting descriptor value")
        self.value = value

    def __delete__(self, instance):
        
        # Called to delete the value of a descriptor.
        
        print("Deleting descriptor value")
        del self.value


# Usage Example
e = Example(10)
print(e.some_attr)  # __getattr__
print(e.value)  # __getattribute__
e.value = 20  # __setattr__
del e.value  # __delattr__
e['key'] = 'value'  # __setitem__
print(e['key'])  # __getitem__
del e['key']  # __delitem__
print(e(1, 2, a=3, b=4))  # __call__
print(len(e))  # __len__
for item in e:  # __iter__, __next__
    print(item)
print('key' in e)  # __contains__
with e as ex:  # __enter__, __exit__
    print(ex)
print(hash(e))  # __hash__
print(str(e))  # __str__
print(format(e, ''))  # __format__
print(repr(e))  # __repr__
print(bool(e))  # __bool__
copy_e = copy.copy(e)  # __copy__
deepcopy_e = copy.deepcopy(e)  # __deepcopy__
# diff between __copy__ and __deepcopy__
# __copy__ is used to create a shallow copy of the object
# __deepcopy__ is used to create a deep copy of the object

state = e.__getstate__()  # __getstate__
e.__setstate__(state)  # __setstate__
reduce_e = e.__reduce__()  # __reduce__
reduce_ex_e = e.__reduce_ex__(2)  # __reduce_ex__

# Descriptor Example
class Owner:
    descriptor = Example(30)

owner = Owner()
print(owner.descriptor)  # __get__
owner.descriptor = 40  # __set__
del owner.descriptor  # __delete__
