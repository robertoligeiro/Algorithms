// LeetCode284. Peeking Iterator.cpp : Defines the entry point for the console application.
//

//https://leetcode.com/problems/peeking-iterator/description/
#include "stdafx.h"
#include <vector>
using std::vector;

class Iterator {
	struct Data;
	Data* data;
public:
	Iterator(const vector<int>& nums);
	Iterator(const Iterator& iter);
	virtual ~Iterator();
	// Returns the next element in the iteration.
	int next();
	// Returns true if the iteration has more elements.
	bool hasNext() const;
};


class PeekingIterator : public Iterator {
private:
	int nextValue;
	bool hasNextBool;
	void GetNext(void)
	{
		hasNextBool = Iterator::hasNext();
		if (hasNextBool)
		{
			nextValue = Iterator::next();
		}
	}

public:
	PeekingIterator(const vector<int>& nums) : Iterator(nums) {
		// Initialize any member here.
		// **DO NOT** save a copy of nums and manipulate it directly.
		// You should only use the Iterator interface methods.
		GetNext();
	}

	// Returns the next element in the iteration without advancing the iterator.
	int peek() {
		return nextValue;
	}

	// hasNext() and next() should behave the same as in the Iterator interface.
	// Override them if needed.
	int next() {
		int ret = nextValue;
		GetNext();
		return ret;
	}

	bool hasNext() const {
		return hasNextBool;
	}
};

int main()
{
    return 0;
}

