# GeekSeat Dev Test!

This site contains the solution to beat the witch!!

# Problem

Somewhere far far away, there is a village which is controlled by a dark and cunning witch.
Coincidentally, this witch is also a die-hard programmer.
The witch has power to control death and life of the villager.
The witch will kill a number of villagers each year.
Since the witch is a die hard programmer, she follow a specific rule to decide the number of villagers
she should kill each year.
On the 1st year she kills 1 villager
On the 2nd year she kills 1 + 1 = 2 villagers
On the 3rd year she kills 1 + 1 + 2 = 4 villagers
On the 4th year she kills 1 + 1 + 2 + 3 = 7 villagers
On the 5th year she kills 1 + 1 + 2 + 3 + 5 = 12 villagers
And so on...
The villagers are furious with the witch and want to get rid of her and there is one way to get rid of
her.
The witch will only leave if there is a brave programmer in the villager who can create a program to
solve this problem:
If given two people whose age of death and year of death are known, find the average number of
people the witch killed on year of birth of those people
Example:
Given:
Person A: Age of death = 10, Year of Death = 12
Person B: Age of death = 13, Year of Death = 17
Answer:
Person A born on Year = 12 – 10 = 2, number of people killed on year 2 is 2.
Person B born on Year = 17 – 13 = 4, number of people killed on year 4 is 7.
So the average is ( 7 + 2 )/2 = 4.5
If you give invalid data (i.e. negative age, person who born before the witch took control) the
program should return -1.


## How to solve it?
### First
Let's see the sequence that used to calculate the death toll for each year.
Year 1 => 1
Year 2 => 1 1
Year 3 => 1 1 2
Year 4 => 1 1 2 3
Year 5 => 1 1 2 3 5
As you can see, it's a fibonacci sequence, therefore we need a function to calculate <em>n</em>-th fibonacci number.
If the <em>n</em> was less than 1, it should return -1 because the input was invalid.
Let's call this function <em>Fibonacci(n)</em>

### Second
Let's see how to calculate the death toll for each year.
Year 1 => 1
Year 2 => 1 + 1 = 2
Year 3 => 1 + 1 + 2 = 4
Year 4 => 1 + 1 + 2 + 3 = 7
Year 5 => 1 + 1 + 2 + 3 + 5 = 12
Let's say we have a function to get the death toll of <em>n</em>-th year called <em>GetDeath(year)</em>
Above sequence could be changed to
Year 1 => GetDeath(1)
Year 2 => GetDeath(1) + Fibonacci(2)
Year 3 => GetDeath(2) + Fibonacci(3)
Year 4 => GetDeath(3) + Fibonacci(4)
Year 5 => GetDeath(4) + Fibonacci(5)
It looks simpler, then we can create a formula for <em>GetDeath(year)</em> = <em>GetDeath(year - 1)</em> - <em>Fibonacci(year)</em>
If the year was less than 1, it should return -1, because of invalid input

### Algorithm
<ol>
<li> Create the Fibonacci function.</li>
<li> Create the GetDeath function using this formula, <em>GetDeath(year)</em> = <em>GetDeath(year - 1)</em> - <em>Fibonacci(year)</em>.</li>
<li> Calculate the GetDeath for each person, if one of the results is -1, the algorithm must stop and return -1. We use <em>All or Nothing</em> principle.</li>
<li> Calculate the average of death tolls from step 3.</li>
</ol>

### Pseudocode
```
fibonacci(n)
	if n less than 1
		return -1
	return fibonacci(n - 1) + fibonacci(n - 2)

getDeath(year)
	if year less than 1
		return -1
	return getDeath(year - 1) + fibonacci(year)

getAverageDeath(people)
	if len(people) less than 1
		return -1
	total <- 0
	count <- 0
	for each person in people
		death <- getDeath(person->YearOfDeath - person->AgeOfDeath)
		if death less than -1
			return -1
		total <- total + death
		count <- count + 1
	return total / count
```
### Improvements
- Use cache to store the calculated fibonacci numbers.
- Use cache to store the calculated death toll for each year.
