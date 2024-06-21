# **This is a File that basicly works like a ini System that allows you to save things to disk**

# Pini Syntax 



##Comments 
**Comments are defined with "!C:"

### EXAMPLE 
```
!C: This line in the pini file is now commented out 
```

##KEYS
**Keys** are basicly the main Data Type in the pini File. 
They have a **String** Defined as a name. 
A **String** for it's value and a **String Array** for args.

They are defined with the **KEY:** label.

KEY:VALUENAME:VALUE:(All args separated by ':')

### PINI SYNTAX EXAMPLE
```
KEY:HelloWorld:HiMom:Arg1:Arg2:Arg3
```

### The Result values when parsed in C# if you defined them yourself. 

(Defined a key with the name "HelloWorld" with the value "HiMom" and with 3 arguments witch will be added in the string[]. Every ':' separates the strings) 
```
string name = "HelloWorld";
string value = "HiMom";
string[] args = new string[] {"Arg1","Arg2","Arg3" };
```

##Structs 
**Structs** are basicly like Key Classes with predefined keynames and it's own name. You can use them to make basicly key Objects. 
Structs have a name 
And you can define keys with names.
### Example Syntax
```
STRUCT-MYSTRUCT
  KEY:MYKEY1
  KEY:MYKEY2
END
```
This defines a struct Type called MYSTRUCT. With 2 values called MyKey1 and MyKey2. 

### How to instance them 
You use the NEW Keyword
It Works like this 
"NEW-StructDefinitionName-Variblename:(values for Keys in the order they are definted in the struct)" 
To define args to variblds when instancing a struct. Inside the ':' arg. Place 'args-' and then define eatch element separating with a '-'.
For example 

**NEW-MYSTRUCT-TestObject:Hello args-Arg1-Arg2-Arg3:World!**

### EXAMPLE CODE

```
!C: Stuct Definition
STRUCT-MYSTRUCT
  KEY:MYKEY1
  KEY:MYKEY2
END
!C: Creates a Instance of MYSTRUCT with MYKEY1 having it's value be "HelloWorld" and it having the arguments {"Hello","There","Lol" } in the args String[] in it's key instance
!C: And MYKEY2 having the string value of "Hello" with no arguments
NEW-MYSTRUCT-myInstance:HelloWorld args-Hello-There-LOL:Hello
```



## SECTIONS
**Sections are the main element in the PINI file. They work as containers for Keys and other Sections and also Instances of Structs. (Explained Below)**

They are defined like this:
```
SECTION-(Sectionname) 

END
```

**They then can store Keys,Instances and other sections inside them like a Directory Tree. Every pini file by default has a Root Section And then when you define child sections it works like a FileTree. 
If you define sturcts in inside sections the Definition will only be avalible in Child sections of the section you define the type in.** 

##Example Code 
```
!C: Here is the root section
KEY:RootKey:Root
!C: Defines a struct called MyStruct in the root section
STRUCT-MyStruct
  KEY:MyKey1
  KEY:MyKey2 
EMD
!C: Defines a child section in the root section Called MYSECTION
SECTION-MYSECTION
  !C: This is now in the MYSECTION section
  KEY:KeyInSection:True

  !C: Defines a struct that only exists in Child sections of this section (So you cannot make a instance of this object in the root section only in MYSECTION and any Child sections of MYSECTION
  STRUCT-PRIVATESTRUCT
    KEY:MYPRIVATEKEY1
    KEY:MYPRIVATEKEY2
  END
  !C: Only valid Here 
  NEW-PRIVATESTRUCT-MyPrivateInstance:HA args-Ha-Ha:HA

  SECTION-ChildToMySection
    !C: And so on
      KEY:MyOtherKey:Hello
  END
END 

```

## Librarys 

**You can also import sturct definitions from other pini files But they can only be sturcts defined in the root section.
**

### Example 

**Here's the lib file. Let's call it Lib.pini 

(Lib.pini's contents) 

```
STRUCT-LIBSTRUCT1
  KEY:LIBKEY1
  KEY:LIBKEY2
END
STRUCT-LIBSTRUCT2
  KEY:Books
END

SECTION-LIBSECTION
  !C: This STRUCT wont be imported due to being in a section Other then the root section of the pini
  STRUCT-LIBSTRUCT3
    KEY:MONEY
  END

END 
```

Now Let's import it into our Code earlier in the guide using the. "IMPORT-(Path to file)" Keyword.
Let's say the lib is in the same directory as the Original PINI file.


```
!C: Import Library
IMPORT-Lib.pini
!C: Here is the root section
KEY:RootKey:Root
!C: Defines a struct called MyStruct in the root section
STRUCT-MyStruct
  KEY:MyKey1
  KEY:MyKey2 
EMD
!C: Defines a child section in the root section Called MYSECTION
SECTION-MYSECTION
  !C: This is now in the MYSECTION section
  KEY:KeyInSection:True

  !C: Defines a struct that only exists in Child sections of this section (So you cannot make a instance of this object in the root section only in MYSECTION and any Child sections of MYSECTION
  STRUCT-PRIVATESTRUCT
    KEY:MYPRIVATEKEY1
    KEY:MYPRIVATEKEY2
  END
  !C: Only valid Here 
  NEW-PRIVATESTRUCT-MyPrivateInstance:HA args-Ha-Ha:HA

  SECTION-ChildToMySection
    !C: And so on
      KEY:MyOtherKey:Hello
  END
END 
!C: Make a instance of a struct from the imported Library 
NEW-LIBSTRUCT1:Hello:World
```

That's the basic syntax of the PINI file.


Look at Program.CS for a example on how to use the file.
