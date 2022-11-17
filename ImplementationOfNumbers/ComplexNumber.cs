public class ComplexNumber
{
    private float real;
    private float imaginary;
    public ComplexNumber(float real, float complex)
    {
        this.real = real;
        this.imaginary = complex;
    }
    
    public static bool operator ==(ComplexNumber X, ComplexNumber Y) =>
        X.real == Y.real && X.imaginary == Y.imaginary;
    public static bool operator !=(ComplexNumber X, ComplexNumber Y) =>
        X.real != Y.real || X.imaginary != Y.imaginary;
    public static ComplexNumber operator +(ComplexNumber X, ComplexNumber Y)
    {
        ComplexNumber result = new ComplexNumber(0, 0);
        result.real = X.real + Y.real;
        result.imaginary = X.imaginary + Y.imaginary;

        return result;
    }

    public static ComplexNumber operator -(ComplexNumber X, ComplexNumber Y)
    {
        ComplexNumber result = new ComplexNumber(0, 0);
        result.real = X.real - Y.real;
        result.imaginary = X.imaginary - Y.imaginary;

        return result;
    }

    public static ComplexNumber operator *(ComplexNumber X, ComplexNumber Y)
    {
        ComplexNumber result = new ComplexNumber(0, 0);
        float a = X.real;
        float b = X.imaginary;
        float c = Y.real;
        float d = Y.imaginary;

        result.real = a * c - b * d;
        result.imaginary = a * d + c * b;

        return result;
    }

    public static ComplexNumber operator /(ComplexNumber X, ComplexNumber Y)
    {
        ComplexNumber result = new ComplexNumber(0, 0);
        float a = X.real;
        float b = X.imaginary;
        float c = Y.real;
        float d = Y.imaginary;
        float divisao = c * c + d * d;

        result.real = (a * c + b * d) / divisao;
        result.imaginary = (c * b - a * d) / divisao;

        return result;
    }
    
    public override string ToString() => 
        $"{this.real} + {this.imaginary}i";
}