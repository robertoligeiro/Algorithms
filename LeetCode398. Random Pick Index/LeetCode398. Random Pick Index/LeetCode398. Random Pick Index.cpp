// LeetCode398. Random Pick Index.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <vector>
#include <stdlib.h>
using std::vector;

// https://leetcode.com/problems/random-pick-index/
class Solution {
private:
	vector<int> _nums;
public:
	Solution(vector<int> nums) {
		_nums = nums;
	}

	int pick(int target) {
		
		int count = 1;
		int resp = 0;
		int i = 0;
		for (vector<int>::iterator it = _nums.begin(); it != _nums.end(); ++it,++i)
		{
			if (*it != target) continue;
			else
			{
				int r = rand() % count + 1;
				count++;
				if (r == 1)
				{
					resp = i;
				}
			}
		}
		return resp;
	}
};
int main()
{
	int myints[] = { 1,2,3,3,3};
	std::vector<int> v(myints, myints + sizeof(myints) / sizeof(int));
	Solution *s = new Solution(v);

	s->pick(3);
    return 0;
}

