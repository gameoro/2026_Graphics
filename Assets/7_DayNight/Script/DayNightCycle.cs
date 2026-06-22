using UnityEngine;


public class DayNightCycle : MonoBehaviour {

	// 게임 시간
	[Header("Time")]
	public float  dayLangeh = 0.25f;		// 하루 길이 (단위: 분)
	private float timeScale;				// 시간 배속 (현실↔게임)
	private float timePercent;              // 하루 경과 퍼센트

	// 태양
	[Header("SunLight")]
	public Transform dayRot;            // 하루 회전 (부모)
	public Light	sun;				// 태양
	public Gradient sunColor;           // 빛 색상
	private float	sunMult = 1.5f;		// 빛 세기 변동

	// 스카이박스
	private Material skyboxMat;


	private void Start() {
		SetTimeScale();

		skyboxMat = new Material(RenderSettings.skybox);	// 원본 복사
		RenderSettings.skybox = skyboxMat;					// 적용
	}
	private void Update() {
		UpdateTime();
		UpdateSun();
	}


	// 시간 배속설정
	private void SetTimeScale() {
		timeScale = 24 / (dayLangeh / 60);          // 게임시간 배속 = 24시간 / (게임하루 길이 / 60분)
	}

	// 시간 업데이트
	private void UpdateTime() {
		timePercent += Time.deltaTime * timeScale / 86400;		// 하루 시간누적
		if (timePercent >= 1.0f) { timePercent -= 1.0f; }		// 하루 끝 → 초기화
	}


	// 태양 업데이트
	private void UpdateSun() {
		// 회전
		float angle = timePercent * 360f;
		dayRot.transform.localRotation = Quaternion.Euler(0, 0, angle);

		//밝기
		float height = Vector3.Dot(sun.transform.forward, Vector3.down);		// 내적 → 높이
		sun.intensity = Mathf.Clamp(height, 0, 1) * 1 * sunMult;                    // 높이 * 변동 → 빛 세기

		// 색상
		sun.color = sunColor.Evaluate(height);                                  // 높이 → 색상

		UpdateSkybox(height);		// 태양 고도 → 스카이박스
	}


	// 스카이박스 업데이트
	private void UpdateSkybox(float height) {
		skyboxMat.SetFloat("_sunHeight", height);
	}
}