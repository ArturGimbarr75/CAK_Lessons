using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthForPlayer : MonoBehaviour
{
    public UnityEventStealth OnGetWorried;
    public UnityEventStealth OnReact;
    public UnityEventStealth OnLoseTarget;
    public UnityEventStealth OnCalmDown;

    [SerializeField, Min(0)] private float _timeToReact;
    [SerializeField, Min(0)] private float _timeToForgetTarget;

    private Scanner _scanner;
    private StealthEventArgs _args;
    private Transform _target;
    private bool _reacted = false;
    private float _woriedTimer = 0;

    private Coroutine _startWoriedTimerCoroutine;
    private Coroutine _endWoriedTimerCoroutine;

    void Awake()
    {
        _scanner = GetComponent<Scanner>();
        OnGetWorried ??= new UnityEventStealth();
        OnReact ??= new UnityEventStealth();
        OnLoseTarget ??= new UnityEventStealth();
        OnCalmDown ??= new UnityEventStealth();
    }

    void Start()
    {
        _scanner.OnScannerViewEnter.AddListener(OnScannerViewEnter);
        _scanner.OnScannerViewExit.AddListener(OnScannerViewExit);
    }

    void OnScannerViewEnter(ScannerEventArgs args)
    {
        if (!args.TargetType.Equals(CharacterType.Type.Player))
            return;

        if (!_reacted)
        {
            _args = new StealthEventArgs
            {
                Sender = transform,
                Target = _target,
                ReactionTime = _timeToReact,
                ForgetTargetTime = _timeToForgetTarget,
                ElapsedReactionTime = _woriedTimer,
                TargetTypes = args.TargetType
            };
            _target = args.Target;
            if (_endWoriedTimerCoroutine != null)
                StopCoroutine(_endWoriedTimerCoroutine);
            _startWoriedTimerCoroutine = StartCoroutine(StartWoriedTimer());
        }
        else
            CancelInvoke(nameof(CalmDown));
    }

    void OnScannerViewExit(ScannerEventArgs args)
    {
        if (!args.TargetType.Equals(CharacterType.Type.Player))
            return;

        if (!_reacted)
        {
            _target = args.Target;
            if (_startWoriedTimerCoroutine != null)
                StopCoroutine(_startWoriedTimerCoroutine);
            _endWoriedTimerCoroutine = StartCoroutine(EndWoriedTimer());
        }
        else if (!IsInvoking(nameof(CalmDown)))
            Invoke(nameof(CalmDown), _timeToForgetTarget);
    }

    IEnumerator StartWoriedTimer()
    {
        _args.ElapsedReactionTime = _woriedTimer;
        OnGetWorried?.Invoke(_args);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (_woriedTimer < _timeToReact)
        {
            _woriedTimer += Time.deltaTime;
            yield return wait;
        }
        _woriedTimer = _timeToReact;
        _reacted = true;
        OnReact?.Invoke(_args);
    }

    IEnumerator EndWoriedTimer()
    {
        _args.ElapsedReactionTime = _woriedTimer;
        OnLoseTarget?.Invoke(_args);
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (_woriedTimer > 0)
        {
            _woriedTimer -= Time.deltaTime;
            yield return wait;
        }
        _woriedTimer = 0;
        _args.ElapsedReactionTime = _woriedTimer;
        OnCalmDown?.Invoke(_args);
    }

    void CalmDown()
    {
        _woriedTimer = 0;
        _reacted = false;
        OnCalmDown?.Invoke(_args);
    }
}
