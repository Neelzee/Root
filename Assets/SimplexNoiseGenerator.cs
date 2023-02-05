using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplexNoiseGenerator
{
	private readonly int[] _a = new int[3];
	private float _s, _u, _v, _w;
	private int _i, _j, _k;
	private const float OneThird = 0.333333333f;
	private const float OneSixth = 0.166666667f;
	private readonly int[] _t;

	public SimplexNoiseGenerator()
	{
		var rand = new System.Random();
		_t = new int[8];
		for (int q = 0; q < 8; q++)
		{
			_t[q] = rand.Next();
		}
	}

	

	// Simplex Noise Generator
	public float Noise(float x, float y, float z) {
		_s = (x + y + z) * OneThird;
		_i = FastFloor(x + _s);
		_j = FastFloor(y + _s);
		_k = FastFloor(z + _s);

		_s = (_i + _j + _k) * OneSixth;
		_u = x - _i + _s;
		_v = y - _j + _s;
		_w = z - _k + _s;

		_a[0] = 0; _a[1] = 0; _a[2] = 0;

		int hi = _u >= _w ? _u >= _v ? 0 : 1 : _v >= _w ? 1 : 2;
		int lo = _u < _w ? _u < _v ? 0 : 1 : _v < _w ? 1 : 2;

		return Kay(hi) + Kay(3 - hi - lo) + Kay(lo) + Kay(0);
	}

	private float Kay(int a) {
		_s = (_a[0] + _a[1] + _a[2]) * OneSixth;
		float x = _u - _a[0] + _s;
		float y = _v - _a[1] + _s;
		float z = _w - _a[2] + _s;
		float t = 0.6f - x * x - y * y - z * z;
		int h = Shuffle(_i + _a[0], _j + _a[1], _k + _a[2]);
		_a[a]++;
		if (t < 0) return 0;
		int b5 = h >> 5 & 1;
		int b4 = h >> 4 & 1;
		int b3 = h >> 3 & 1;
		int b2 = h >> 2 & 1;
		int b1 = h & 3;

		float p = b1 == 1 ? x : b1 == 2 ? y : z;
		float q = b1 == 1 ? y : b1 == 2 ? z : x;
		float r = b1 == 1 ? z : b1 == 2 ? x : y;

		p = b5 == b3 ? -p : p;
		q = b5 == b4 ? -q : q;
		r = b5 != (b4 ^ b3) ? -r : r;
		t *= t;
		return 8 * t * t * (p + (b1 == 0 ? q + r : b2 == 0 ? q : r));
	}

	private int Shuffle(int i, int j, int k) {
		return B(i, j, k, 0) + B(j, k, i, 1) + B(k, i, j, 2) + B(i, j, k, 3) + B(j, k, i, 4) + B(k, i, j, 5) + B(i, j, k, 6) + B(j, k, i, 7);
	}

	private int B(int i, int j, int k, int b) {
		return _t[SimplexNoiseGenerator.B(i, b) << 2 | SimplexNoiseGenerator.B(j, b) << 1 | SimplexNoiseGenerator.B(k, b)];
	}

	private static int B(int n, int b) {
		return n >> b & 1;
	}

	private static int FastFloor(float n) {
		return n > 0 ? (int)n : (int)n - 1;
	}
}
