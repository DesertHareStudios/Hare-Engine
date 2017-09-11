#pragma once

class Color {

public:
	float r;
	float g;
	float b;
	float a;

	Color(float r, float g, float b, float a) {
		this->r = r;
		this->g = g;
		this->b = b;
		this->a = a;
	}
	Color(float r, float g, float b) {
		this->r = r;
		this->g = g;
		this->b = b;
		this->a = 1.0;
	}
	Color() {
		this->r = 0.0;
		this->g = 0.0;
		this->b = 0.0;
		this->a = 0.0;
	}

	static Color interpolate(Color from, Color to, float t) {
		return Color(
			from.r + (to.r - from.r) * t,
			from.g + (to.g - from.g) * t,
			from.b + (to.b - from.b) * t,
			from.a + (to.a - from.a) * t
		);
	}

	Color operator+(const Color& color) {
		Color out;
		out.r = this->r + color.r;
		if (out.r > 1.0) {
			out.r = 1.0;
		}
		out.g = this->g + color.g;
		if (out.g > 1.0) {
			out.g = 1.0;
		}
		out.b = this->b + color.b;
		if (out.b > 1.0) {
			out.b = 1.0;
		}
		out.a = this->a + color.a;
		if (out.a > 1.0) {
			out.a = 1.0;
		}
		return out;
	}

	Color operator-(const Color& color) {
		Color out;
		out.r = this->r - color.r;
		if (out.r < 0.0) {
			out.r = 0.0;
		}
		out.g = this->g - color.g;
		if (out.g < 0.0) {
			out.g = 0.0;
		}
		out.b = this->b - color.b;
		if (out.b < 0.0) {
			out.b = 0.0;
		}
		out.a = this->a - color.a;
		if (out.a < 0.0) {
			out.a = 0.0;
		}
		return out;
	}

	Color operator*(const Color& color) {
		Color out;
		out.r = this->r * color.r;
		if (out.r > 1.0) {
			out.r = 1.0;
		}
		out.g = this->g * color.g;
		if (out.g > 1.0) {
			out.g = 1.0;
		}
		out.b = this->b * color.b;
		if (out.b > 1.0) {
			out.b = 1.0;
		}
		out.a = this->a * color.a;
		if (out.a > 1.0) {
			out.a = 1.0;
		}
		return out;
	}

	Color operator/(const Color& color) {
		Color out;
		if (color.r > 0) {
			out.r = this->r / color.r;
		} else if(this->r > 0.0) {
			out.r = 1.0;
		} else {
			out.r = 0.0;
		}
		if (color.g > 0) {
			out.g = this->g / color.g;
		} else if(this->g > 0.0) {
			out.g = 1.0;
		} else {
			out.g = 0.0;
		}
		if (color.b > 0) {
			out.b = this->b / color.b;
		} else if(this->b > 0.0){
			out.b = 1.0;
		} else {
			out.b = 0.0;
		}
		if (color.a > 0) {
			out.a = this->a / color.a;
		} else if(this->a > 0.0) {
			out.a = 1.0;
		} else {
			out.a = 0.0;
		}
		return out;
	}

};