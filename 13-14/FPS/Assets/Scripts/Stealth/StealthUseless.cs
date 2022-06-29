using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
public class StealthUseless : MonoBehaviour
{
    public UnityEventStealth OnSawTarget;
    public UnityEventStealth OnGetWorried;
    public UnityEventStealth OnReact;
    public UnityEventStealth OnLoseTarget;
    public UnityEventStealth OnLoseAllTargets;
    public UnityEventStealth OnCalmDown;

    [SerializeField, Min(0)] private float _timeToReact;
    [SerializeField, Min(0)] private float _timeToForgetTargets;

    private Scanner _scanner;
    private HashSet<StealthTarget> _targets;
    private bool _isReacted;
    private bool _isWoried;

    void Awake()
    {
        OnGetWorried ??= new UnityEventStealth();
        OnReact ??= new UnityEventStealth();
        OnLoseTarget ??= new UnityEventStealth();
        OnCalmDown ??= new UnityEventStealth();
        OnSawTarget ??= new UnityEventStealth();
        OnLoseAllTargets ??= new UnityEventStealth();

        _targets = new HashSet<StealthTarget>();
        _isReacted = false;
        _isWoried = false;
    }

    void Start()
    {
        _scanner ??= GetComponent<Scanner>();
        _scanner?.OnScannerViewEnter.AddListener(OnScannerViewEnter);
        _scanner?.OnScannerViewExit.AddListener(OnScannerViewExit);
    }

    void Update()
    {
        if (!_isReacted)
            foreach (StealthTarget target in _targets)
            {
               target.TimeInViewArea += target.IsVisible? Time.deltaTime : -Time.deltaTime;
                if (target.TimeInViewArea >= _timeToReact && !_isReacted)
                {
                    _isReacted = true;
                    OnReact?.Invoke(new StealthEventArgs
                    {
                        ForgetTargetTime = _timeToForgetTargets,
                        ReactionTime = _timeToReact,
                        Sender = transform,
                        Target = target.Target,
                        TargetTypes = _scanner.TargetsType,
                        //Reacted = _isReacted,
                        //Woried = _isWoried,
                        ElapsedReactionTime = _timeToReact
                    });
                }
            }    

        if ((_isReacted || _isWoried) && !IsInvoking(nameof(CalmDown)) && _targets.Count(x => x.TimeInViewArea <= 0) == 0)
            Invoke(nameof(CalmDown), _timeToForgetTargets);
    }
    

    void OnDisable()
    {
        _scanner.OnScannerViewEnter.RemoveListener(OnScannerViewEnter);
        _scanner.OnScannerViewExit.RemoveListener(OnScannerViewExit);
        _targets.Clear();
    }

    void OnScannerViewEnter(ScannerEventArgs target)
    {
        var temp = new StealthTarget { Target = target.Target, IsVisible = true, Type = target.TargetType };
        if (_targets.TryGetValue(temp, out StealthTarget st))
            st.IsVisible = true;
        else
        { 
            var args = new StealthEventArgs
            {
                ForgetTargetTime = _timeToForgetTargets,
                ReactionTime = _timeToReact,
                Sender = transform,
                Target = target.Target,
                ElapsedReactionTime = _targets.Count > 0? _targets.Max(x => x.TimeInViewArea) : 0,
                TargetTypes = _scanner.TargetsType,
                //Reacted = _isReacted,
                //Woried = _isWoried
            };
            OnSawTarget?.Invoke(args);
            if (_targets.Add(temp) && _targets.Count == 1)
                OnGetWorried?.Invoke(args);
        }
        _isWoried = true;
        CancelInvoke(nameof(CalmDown));
    }

    void OnScannerViewExit(ScannerEventArgs target)
    {
        var temp = new StealthTarget { Target = target.Target };
        if (_targets.TryGetValue(temp, out StealthTarget st))
        {
            var args = new StealthEventArgs
            {
                ForgetTargetTime = _timeToForgetTargets,
                ReactionTime = _timeToReact,
                Sender = transform,
                Target = target.Target,
                TargetTypes = _scanner.TargetsType,
                ElapsedReactionTime = Mathf.Min(_targets.Max(x => x.TimeInViewArea), _timeToReact),
                //Reacted = _isReacted,
                //Woried = _isWoried
            };
            st.IsVisible = false;
            OnLoseTarget?.Invoke(args);
            if (_targets.Count(x => x.IsVisible) == 0)
            { 
                OnLoseAllTargets?.Invoke(args);
                //Invoke(nameof(CalmDown), _timeToForgetTargets);
            }
        }
    }

    void CalmDown()
    {
        _isReacted = false;
        _isWoried = false;
        OnCalmDown?.Invoke(new StealthEventArgs
        {
            ForgetTargetTime = _timeToForgetTargets,
            ReactionTime = _timeToReact,
            Sender = transform,
            TargetTypes = _scanner.TargetsType,
            //Reacted = _isReacted,
            //Woried = _isWoried
        });
        _targets.Clear();
    }
}
