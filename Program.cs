//*****************************************************************************
//** 2040. Kth Smallest Product of Two Sorted Arrays                leetcode **
//*****************************************************************************

int lower_bound(int* arr, int size, long long target)
{
    int left = 0, right = size;
    while (left < right)
    {
        int mid = left + (right - left) / 2;
        if ((long long)arr[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return left;
}

int upper_bound(int* arr, int size, long long target)
{
    int left = 0, right = size;
    while (left < right)
    {
        int mid = left + (right - left) / 2;
        if ((long long)arr[mid] <= target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return left;
}

bool isPossible(long long x, int* nums1, int n1, int* nums2, int n2, long long k)
{
    long long count = 0;
    for (int i = 0; i < n1; i++)
    {
        if (nums1[i] < 0)
        {
            long long rem = (long long)ceil((double)x / nums1[i]);
            int idx = lower_bound(nums2, n2, rem);
            count += (n2 - idx);
        }
        else if (nums1[i] > 0)
        {
            long long rem = (long long)floor((double)x / nums1[i]);
            int idx = upper_bound(nums2, n2, rem);
            count += idx;
        }
        else // nums1[i] == 0
        {
            if (x >= 0)
            {
                count += n2;
            }
        }
        if (count >= k)
        {
            return true;
        }
    }
    return count >= k;
}

long long kthSmallestProduct(int* nums1, int nums1Size, int* nums2, int nums2Size, long long k) {
    long long low = -10000000001LL;
    long long high = 10000000001LL;
    while (low + 1 < high)
    {
        long long mid = low + (high - low) / 2;
        if (isPossible(mid, nums1, nums1Size, nums2, nums2Size, k))
        {
            high = mid;
        }
        else
        {
            low = mid;
        }
    }
    return high;
}