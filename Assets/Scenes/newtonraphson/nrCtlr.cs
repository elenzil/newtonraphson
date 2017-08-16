using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nrCtlr : MonoBehaviour {

  [SerializeField]
  private Button        _btnGraphIt;

  [SerializeField]
  private Graphic       _examplePoint;

  [SerializeField]
  private RectTransform _pointHolder;

  public double xmin;
  public double xmax;
  public double ymin;
  public double ymax;

  private int numGraphSteps = 100;

  private Graphic exampleTickPoint;

  private double f(double x) {
    return x * x + System.Math.Cos(3.0 * x);
  }

  private double df(double x) {
    return x / 2.0 + 3.0 * System.Math.Sin(3.0 * x);
  }

  void Start() {
    _btnGraphIt.onClick.AddListener(OnClickGraphIt);
    GraphIt();
  }

  private void OnClickGraphIt() {
    GraphIt();
  }

  private void GraphIt() {
    ClearPoints();
    double xrng = xmax - xmin;
    double xstp = xrng / (double)(numGraphSteps - 1);
    for (int n   = 0; n < numGraphSteps; ++n) {
      double x   = (double)n * xstp + xmin;
      double fy  =  f(x);
      double dfy = df(x);
      PlotPoint((float)x, (float)fy , Color.white);
      PlotPoint((float)x, (float)dfy, Color.grey );
    }
  }

  private void ClearPoints () {
    for (int n = 0; n < _pointHolder.childCount; ++n) {
      GameObject.Destroy(_pointHolder.GetChild(n).gameObject);
    }
  }

  private void PlotPoint (float x, float y, Color c) {
    Graphic g = Instantiate<Graphic>(_examplePoint);
    g.transform.SetParent(_pointHolder);
    g.transform.localScale = Vector3.one;

    float nx = Mathf.InverseLerp((float)xmin, (float)xmax, x);
    float ny = Mathf.InverseLerp((float)ymin, (float)ymax, y);

    float lx = Mathf.Lerp(_pointHolder.rect.min.x, _pointHolder.rect.max.x, nx);
    float ly = Mathf.Lerp(_pointHolder.rect.min.y, _pointHolder.rect.max.y, ny);
    

    g.transform.localPosition = new Vector3(lx, ly, 0);
    g.color = c;
  }

}

public static class oxeNewtonRaphson<Types> {

  public delegate double aFunction(double val);

  public static double solve(aFunction theFunction, aFunction theDerivative, double initialGuess) {
    return 0;
  }
}
