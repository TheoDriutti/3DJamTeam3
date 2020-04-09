using UnityEngine;
using System.Collections;

public class ClockTimer : MonoBehaviour {
	[HideInInspector] public int initialHoursValue;
    [HideInInspector] public int initialMinutesValue;
    [HideInInspector] public int initialSecondsValue;
    [HideInInspector] public float clockSpeed =1.0f;
    public float clockSpeedAsk = 1.0f;
    [HideInInspector] public bool pointFlicker =true;
	[HideInInspector] public bool reverse=false;
    public DisplaySelectedObject _display;


    [Range(0,24)]
    public int _heureDeDebut;
    [Range(0, 24)]
    public int _heureDeFin;

    public static bool _isCardVisible;
    public GameObject _cardManager;

    private DigitalClock digitalClock;
	private AnalogicClock analogicClock;

    void Awake()
    {
        Commencer();
    }
    public void Commencer()
    {
            clockSpeed = clockSpeedAsk;
            FindObjectOfType<DigitalClockValue>().reverse = false;
            FindObjectOfType<DigitalClock>().SetReverseClock(false);
            initialHoursValue = _heureDeDebut;
    }

    public void RetourEnArriere()
    {
        _isCardVisible = true;
        FindObjectOfType<DigitalClockValue>().reverse = true;
        FindObjectOfType<DigitalClock>().SetReverseClock(true);
        FindObjectOfType<DigitalClock>().clockSpeed = clockSpeedAsk*10;
    }

    void OnEnable () {
		digitalClock = transform.GetComponentInChildren<DigitalClock> ();
		analogicClock = transform.GetComponentInChildren<AnalogicClock>();
		if (digitalClock != null) {
			digitalClock.clockSpeed = clockSpeed;
			if (!pointFlicker)digitalClock.pointFlicker=false;
			if (digitalClock.hoursDCV!=null)digitalClock.hoursDCV.ChangeToTargetTime (initialHoursValue);
			if (digitalClock.minutesDCV!=null)digitalClock.minutesDCV.ChangeToTargetTime (initialMinutesValue);
			if (digitalClock.secondsDCV!=null)digitalClock.secondsDCV.ChangeToTargetTime (initialSecondsValue);
		}
		if (analogicClock != null) {
			if (reverse)analogicClock.clockSpeed=-clockSpeed;
			else analogicClock.clockSpeed=clockSpeed;
			analogicClock.SetTime(initialHoursValue,initialMinutesValue,initialSecondsValue);
		}
	}
	
	void Update ()
    {
        if (!_isCardVisible)
            Chrono();
    }

    public void EteindreLaCard()
    {
        _isCardVisible = false;
        FindObjectOfType<FlashLight>().IsLifeUpOrDown();
        _cardManager.SetActive(false);
        FindObjectOfType<WavesManager>().NewWave();
        clockSpeed = clockSpeedAsk;
        
    }

    void Chrono()
    {
        if (digitalClock != null)
        {
            digitalClock.clockSpeed = clockSpeed;
        }
    }
}
