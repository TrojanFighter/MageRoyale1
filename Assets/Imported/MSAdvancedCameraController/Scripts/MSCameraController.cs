using UnityEngine;
using System;

[Serializable]
public class CameraType {
	[Tooltip("A camera must be associated with this variable. The camera that is associated here, will receive the settings of this index.")]
	public Camera _camera;
	public enum TipoRotac{LookAtThePlayer, FirstPerson, FollowPlayer, Orbital, Stop, StraightStop, OrbitalThatFollows, ETS_StyleCamera}
	[Tooltip("Here you must select the type of rotation and movement that camera will possess.")]
	public TipoRotac rotationType = TipoRotac.LookAtThePlayer;
	[Range(0.01f,1.0f)][Tooltip("Here you must adjust the volume that the camera attached to this element can perceive. In this way, each camera can perceive a different volume.")]
	public float volume = 1.0f;
}
[Serializable]
public class CameraSetting {
	[Tooltip("The input that will define the horizontal movement of the cameras.")]
	public string inputMouseX = "Mouse X";
	[Tooltip("The input that will define the vertical movement of the cameras.")]
	public string inputMouseY = "Mouse Y";
	[Tooltip("The input that allows you to zoom in or out of the camera.")]
	public string inputMouseScrollWheel = "Mouse ScrollWheel";
	[Space(10)][Tooltip("In this variable you can configure the key responsible for switching cameras.")]
	public KeyCode cameraSwitchKey = KeyCode.C;
	[Space(10)][Tooltip("In this class you can configure the 'FirstPerson' style cameras.")]
	public SettingsCameraFirstPerson firstPerson;
	[Tooltip("In this class you can configure the 'FollowPlayer' style cameras.")]
	public SettingsCameraFollow followPlayer;
	[Tooltip("In this class you can configure the 'Orbital' style cameras.")]
	public SettingsCameraOrbital orbital;
	[Tooltip("In this class you can configure the 'OrbitalThatFollows' style cameras.")]
	public SettingsCameraOrbitalThatFollows OrbitalThatFollows;
	[Tooltip("In this class you can configure the 'ETS_StyleCamera' style cameras.")]
	public SettingsCameraETS_StyleCamera ETS_StyleCamera;
}
[Serializable]
public class SettingsCameraFirstPerson {
	[Range(1,20)][Tooltip("Horizontal camera rotation sensitivity.")]
	public float sensibilityX = 10.0f;
	[Range(1,20)][Tooltip("Vertical camera rotation sensitivity.")]
	public float sensibilityY = 10.0f;
	[Range(0,360)][Tooltip("The highest horizontal angle that camera style 'FistPerson' camera can achieve.")]
	public float horizontalAngle = 65.0f;
	[Range(0,85)][Tooltip("The highest vertical angle that camera style 'FistPerson' camera can achieve.")]
	public float verticalAngle = 20.0f;
	[Range(0,40)][Tooltip("The maximum the camera can approximate your vision.")]
	public float maxScroolZoom = 30.0f;
	[Range(0,1)][Tooltip("The speed with which the camera can approach your vision through the mouseScrool.")]
	public float speedScroolZoom = 0.5f;

	[Space(10)]
	[Tooltip("If this variable is true, the camera will only rotate when the key selected in the 'KeyToRotate' variable is pressed. If this variable is false, the camera can rotate freely, even without pressing any key.")]
	public bool rotateWhenClick = false;
	[Tooltip("Here you can select the button that must be pressed in order to rotate the camera.")]
	public string keyToRotate = "mouse 0";
}
[Serializable]
public class SettingsCameraFollow {
	[Range(1,20)][Tooltip("The speed at which the camera can follow the player.")]
	public float displacementSpeed = 3.0f;
	[Tooltip("If this variable is true, the code makes a lookAt using quaternions.")]
	public bool customLookAt = false;
	[Range(1,30)][Tooltip("The speed at which the camera rotates as it follows and looks at the player.")]
	public float spinSpeedCustomLookAt = 15.0f;
	[Tooltip("If this variable is true, the camera ignores the colliders and crosses the walls freely.")]
	public bool ignoreCollision = false;
}
[Serializable]
public class SettingsCameraOrbital {
	[Range(0.01f,2.0f)][Tooltip("In this variable you can configure the sensitivity with which the script will perceive the movement of the X and Y inputs. ")]
	public float sensibility = 0.8f;
	[Range(0.01f,2.0f)][Tooltip("In this variable, you can configure the speed at which the orbital camera will approach or distance itself from the player when the mouse scrool is used.")]
	public float speedScrool = 1.0f;
	[Range(0.01f,2.0f)][Tooltip("In this variable, you can configure the speed at which the orbital camera moves up or down.")]
	public float speedYAxis = 0.5f;
	[Range(3.0f,20.0f)][Tooltip("In this variable, you can set the minimum distance that the orbital camera can stay from the player.")]
	public float minDistance = 5.0f;
	[Range(20.0f,1000.0f)][Tooltip("In this variable, you can set the maximum distance that the orbital camera can stay from the player.")]
	public float maxDistance = 50.0f;
	[Space(10)]
	[Range(-85,0)][Tooltip("In this variable it is possible to define the minimum angle that the camera can reach on the Y axis")]
	public float minAngleY = 0.0f;
	[Range(0,85)][Tooltip("In this variable it is possible to define the maximum angle that the camera can reach on the Y axis")]
	public float maxAngleY = 80.0f;
	[Tooltip("If this variable is true, the camera ignores the colliders and crosses the walls freely.")]
	public bool ignoreCollision = false;

	[Space(10)]
	[Tooltip("If this variable is true, the camera will only rotate when the key selected in the 'KeyToRotate' variable is pressed. If this variable is false, the camera can rotate freely, even without pressing any key.")]
	public bool rotateWhenClick = false;
	[Tooltip("Here you can select the button that must be pressed in order to rotate the camera.")]
	public string keyToRotate = "mouse 0";
}
[Serializable]
public class SettingsCameraOrbitalThatFollows {
	[Range(1,20)][Tooltip("The speed at which the camera can follow the player.")]
	public float displacementSpeed = 5.0f;
	[Tooltip("If this variable is true, the code makes a lookAt using quaternions.")]
	public bool customLookAt = false;
	[Range(1,30)][Tooltip("The speed at which the camera rotates as it follows and looks at the player.")]
	public float spinSpeedCustomLookAt = 15.0f;

	[Space(10)][Range(0.01f,2.0f)][Tooltip("In this variable you can configure the sensitivity with which the script will perceive the movement of the X and Y inputs. ")]
	public float sensibility = 0.8f;
	[Range(0.01f,2.0f)][Tooltip("In this variable, you can configure the speed at which the orbital camera will approach or distance itself from the player when the mouse scrool is used.")]
	public float speedScrool = 1.0f;
	[Range(0.01f,2.0f)][Tooltip("In this variable, you can configure the speed at which the orbital camera moves up or down.")]
	public float speedYAxis = 0.5f;
	[Range(3.0f,20.0f)][Tooltip("In this variable, you can set the minimum distance that the orbital camera can stay from the player.")]
	public float minDistance = 5.0f;
	[Range(20.0f,1000.0f)][Tooltip("In this variable, you can set the maximum distance that the orbital camera can stay from the player.")]
	public float maxDistance = 50.0f;
	[Space(10)]
	[Range(-85,0)][Tooltip("In this variable it is possible to define the minimum angle that the camera can reach on the Y axis")]
	public float minAngleY = 0.0f;
	[Range(0,85)][Tooltip("In this variable it is possible to define the maximum angle that the camera can reach on the Y axis")]
	public float maxAngleY = 80.0f;
	[Tooltip("If this variable is true, the camera ignores the colliders and crosses the walls freely.")]
	public bool ignoreCollision = false;

	[Space(10)]
	[Tooltip("If this variable is true, the camera will only rotate when the key selected in the 'KeyToRotate' variable is pressed. If this variable is false, the camera can rotate freely, even without pressing any key.")]
	public bool rotateWhenClick = false;
	[Tooltip("Here you can select the button that must be pressed in order to rotate the camera.")]
	public string keyToRotate = "mouse 0";
}
[Serializable]
public class SettingsCameraETS_StyleCamera {
	[Range(1,20)][Tooltip("Horizontal camera rotation sensitivity.")]
	public float sensibilityX = 10.0f;
	[Range(1,20)][Tooltip("Vertical camera rotation sensitivity.")]
	public float sensibilityY = 10.0f;
	[Range(0.5f,3.0f)][Tooltip("The distance the camera will move to the left when the mouse is also shifted to the left. This option applies only to cameras that have the 'ETS_StyleCamera' option selected.")]
	public float ETS_CameraShift = 1.0f;
	[Range(0,40)][Tooltip("The maximum the camera can approximate your vision.")]
	public float maxScroolZoom = 30.0f;
	[Range(0,1)][Tooltip("The speed with which the camera can approach your vision through the mouseScrool.")]
	public float speedScroolZoom = 0.5f;

	[Space(10)]
	[Tooltip("If this variable is true, the camera will only rotate when the key selected in the 'KeyToRotate' variable is pressed. If this variable is false, the camera can rotate freely, even without pressing any key.")]
	public bool rotateWhenClick = false;
	[Tooltip("Here you can select the button that must be pressed in order to rotate the camera.")]
	public string keyToRotate = "mouse 0";
}

public class MSCameraController : MonoBehaviour {

	[Tooltip("If this variable is checked, the script will automatically place the 'IgnoreRaycast' layer on the player when needed.")]
	public bool ajustTheLayers = true;

	[Space(10)][Tooltip("Here you must associate all the cameras that you want to control by this script, associating each one with an index and selecting your preferences.")]
	public CameraType[] cameras = new CameraType[0];
	[Tooltip("Here you can configure the cameras, deciding their speed of movement, rotation, zoom, among other options.")]
	public CameraSetting CameraSettings;

	bool orbitalAtiv;
	int index = 0;
	float rotacX = 0.0f;
	float rotacY = 0.0f;
	float tempoOrbit = 0.0f;
	float rotacXETS = 0.0f;
	float rotacYETS = 0.0f;
	float timeScaleSpeed = 0.0f;
	float tempFloat = 0.0f;
	float movXTemp = 0.0f;
	float movYTemp = 0.0f;
	float movZTemp = 0.0f;

	Vector3 newPosition;
	Vector3 negPosition;
	Vector3 otherPosition;
	Quaternion tempRotation;
	Quaternion tempRotation2;
	Quaternion temp_xQuaternion;
	Quaternion temp_yQuaternion;
	RaycastHit tempHit;

	GameObject[] objPosicStopCameras;
	Quaternion[] originalRotation;
	GameObject[] originalPosition;
	Vector3[] originalPositionETS;
	float[] xOrbit;
	float[] yOrbit;
	float[] distanceFromOrbitalCamera;
	float[] initialFieldOfView;

	void Awake(){

		GameObject temp = new GameObject ("PlayerCams");
		temp.transform.parent = transform;
		objPosicStopCameras = new GameObject[cameras.Length];
		originalRotation = new Quaternion[cameras.Length];
		originalPosition = new GameObject[cameras.Length];
		originalPositionETS = new Vector3[cameras.Length];
		xOrbit = new float[cameras.Length];
		yOrbit = new float[cameras.Length];

		distanceFromOrbitalCamera = new float[cameras.Length];
		initialFieldOfView = new float[cameras.Length];

		for (int x = 0; x < cameras.Length; x++) {
			if (cameras [x]._camera) {
				if (cameras [x].volume == 0) {
					cameras [x].volume = 1;
				}
				distanceFromOrbitalCamera [x] = CameraSettings.orbital.minDistance;
				initialFieldOfView [x] = cameras [x]._camera.fieldOfView;

				if (cameras [x].rotationType == CameraType.TipoRotac.FirstPerson) {
					cameras [x]._camera.transform.parent = temp.transform;
					originalRotation [x] = cameras [x]._camera.transform.localRotation;
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.FollowPlayer) {
					cameras [x]._camera.transform.parent = temp.transform;
					originalPosition [x] = new GameObject ("positionFollowPlayerCamera" + x);
					originalPosition [x].transform.parent = transform;
					originalPosition [x].transform.position = cameras [x]._camera.transform.position;
					if (ajustTheLayers) {
						transform.gameObject.layer = 2;
						foreach (Transform trans in this.gameObject.GetComponentsInChildren<Transform>(true)) {
							trans.gameObject.layer = 2;
						}
					}
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.Orbital) {
					cameras [x]._camera.transform.parent = temp.transform;
					xOrbit [x] = cameras [x]._camera.transform.eulerAngles.x;
					yOrbit [x] = cameras [x]._camera.transform.eulerAngles.y;
					if (ajustTheLayers) {
						transform.gameObject.layer = 2;
						foreach (Transform trans in this.gameObject.GetComponentsInChildren<Transform>(true)) {
							trans.gameObject.layer = 2;
						}
					}
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.Stop) {
					cameras [x]._camera.transform.parent = temp.transform;
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.StraightStop) {
					cameras [x]._camera.transform.parent = temp.transform;
					objPosicStopCameras [x] = new GameObject ("positionStraightStopCamera" + x);
					objPosicStopCameras [x].transform.parent = cameras [x]._camera.transform;
					objPosicStopCameras [x].transform.localPosition = new Vector3 (0, 0, 1.0f);
					objPosicStopCameras [x].transform.parent = transform;
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.OrbitalThatFollows) {
					cameras [x]._camera.transform.parent = temp.transform;
					xOrbit [x] = cameras [x]._camera.transform.eulerAngles.x;
					yOrbit [x] = cameras [x]._camera.transform.eulerAngles.y;

					originalPosition [x] = new GameObject ("positionCameraFollowPlayer" + x);
					originalPosition [x].transform.parent = transform;
					originalPosition [x].transform.position = cameras [x]._camera.transform.position;

					if (ajustTheLayers) {
						transform.gameObject.layer = 2;
						foreach (Transform trans in this.gameObject.GetComponentsInChildren<Transform>(true)) {
							trans.gameObject.layer = 2;
						}
					}
				}

				if (cameras [x].rotationType == CameraType.TipoRotac.ETS_StyleCamera) {
					cameras [x]._camera.transform.parent = temp.transform;
					originalRotation [x] = cameras [x]._camera.transform.localRotation;
					originalPositionETS [x] = cameras [x]._camera.transform.localPosition;
				}

				AudioListener audListner = cameras [x]._camera.GetComponent<AudioListener> ();
				if (audListner == null) {
					cameras [x]._camera.transform.gameObject.AddComponent (typeof(AudioListener));
				}

			} else {
				Debug.LogWarning ("There is no camera associated with the index " + x);
			}
		}
	}

	void Start(){
		EnableCameras (index);
	}

	void EnableCameras (int index){
		if (cameras.Length > 0) {
			for (int x = 0; x < cameras.Length; x++) {
				if (cameras [x]._camera) {
					if (x == index) {
						cameras [x]._camera.gameObject.SetActive (true);
					} else {
						cameras [x]._camera.gameObject.SetActive (false);
					}
				}
			}
		}
	}

	void ManageCameras(){
		for (int x = 0; x < cameras.Length; x++) {
			if (cameras [x].rotationType == CameraType.TipoRotac.FollowPlayer) {
				if (cameras [x]._camera.isActiveAndEnabled) {
					cameras [x]._camera.transform.parent = null;
				} else {
					cameras [x]._camera.transform.parent = transform;
				}
			}
		}
		AudioListener.volume = cameras [index].volume;
		timeScaleSpeed = Mathf.Clamp (1.0f / Time.timeScale, 0.01f, 1);
		switch (cameras[index].rotationType ) {
		case CameraType.TipoRotac.Stop:
			//stop camera
			break;
		case CameraType.TipoRotac.StraightStop:
			tempRotation = Quaternion.LookRotation(objPosicStopCameras[index].transform.position - cameras [index]._camera.transform.position, Vector3.up);
			cameras [index]._camera.transform.rotation = Quaternion.Slerp(cameras [index]._camera.transform.rotation, tempRotation, Time.deltaTime * 15.0f);
			break;
		case CameraType.TipoRotac.LookAtThePlayer:
			cameras [index]._camera.transform.LookAt (transform.position);
			break;
		case CameraType.TipoRotac.FirstPerson:
			if (CameraSettings.firstPerson.rotateWhenClick) {
				if (Input.GetKey (CameraSettings.firstPerson.keyToRotate)) {
					rotacX += Input.GetAxis (CameraSettings.inputMouseX) * CameraSettings.firstPerson.sensibilityX;
					rotacY += Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.firstPerson.sensibilityY;
				}
			} else {
				rotacX += Input.GetAxis (CameraSettings.inputMouseX) * CameraSettings.firstPerson.sensibilityX;
				rotacY += Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.firstPerson.sensibilityY;
			}
			rotacX = ClampAngle (rotacX, -CameraSettings.firstPerson.horizontalAngle, CameraSettings.firstPerson.horizontalAngle);
			rotacY = ClampAngle (rotacY, -CameraSettings.firstPerson.verticalAngle, CameraSettings.firstPerson.verticalAngle);
			temp_xQuaternion = Quaternion.AngleAxis (rotacX, Vector3.up);
			temp_yQuaternion = Quaternion.AngleAxis (rotacY, -Vector3.right);
			tempRotation = originalRotation [index] * temp_xQuaternion * temp_yQuaternion;
			cameras [index]._camera.transform.localRotation = Quaternion.Lerp (cameras [index]._camera.transform.localRotation, tempRotation, Time.deltaTime * 10.0f * timeScaleSpeed);
			//fieldOfView
			cameras [index]._camera.fieldOfView -= Input.GetAxis (CameraSettings.inputMouseScrollWheel)*CameraSettings.firstPerson.speedScroolZoom*50.0f;
			if (cameras [index]._camera.fieldOfView < (initialFieldOfView [index] - CameraSettings.firstPerson.maxScroolZoom)) {
				cameras [index]._camera.fieldOfView = (initialFieldOfView [index] - CameraSettings.firstPerson.maxScroolZoom);
			}
			if (cameras [index]._camera.fieldOfView > initialFieldOfView [index]) {
				cameras [index]._camera.fieldOfView = (initialFieldOfView [index]);
			}
			break;
		case CameraType.TipoRotac.FollowPlayer:
			if (!Physics.Linecast (transform.position, originalPosition [index].transform.position)) {
				cameras [index]._camera.transform.position = Vector3.Lerp (cameras [index]._camera.transform.position, originalPosition [index].transform.position, Time.deltaTime * CameraSettings.followPlayer.displacementSpeed);
			} else if (Physics.Linecast (transform.position, originalPosition [index].transform.position, out tempHit)) {
				if (CameraSettings.followPlayer.ignoreCollision) {
					cameras [index]._camera.transform.position = Vector3.Lerp (cameras [index]._camera.transform.position, originalPosition [index].transform.position, Time.deltaTime * CameraSettings.followPlayer.displacementSpeed);
				} else {
					cameras [index]._camera.transform.position = Vector3.Lerp (cameras [index]._camera.transform.position, tempHit.point, Time.deltaTime * CameraSettings.followPlayer.displacementSpeed);
				}
			}
			//
			if (CameraSettings.followPlayer.customLookAt) {
				tempRotation = Quaternion.LookRotation (transform.position - cameras [index]._camera.transform.position, Vector3.up);
				cameras [index]._camera.transform.rotation = Quaternion.Slerp (cameras [index]._camera.transform.rotation, tempRotation, Time.deltaTime * CameraSettings.followPlayer.spinSpeedCustomLookAt);
			} else {
				cameras [index]._camera.transform.LookAt (transform.position);
			}
			break;
		case CameraType.TipoRotac.Orbital:
			tempFloat = CameraSettings.orbital.minDistance;
			if (!Physics.Linecast (transform.position, cameras [index]._camera.transform.position)) {

			} else if (Physics.Linecast (transform.position, cameras [index]._camera.transform.position, out tempHit)) {
				if (!CameraSettings.orbital.ignoreCollision) {
					distanceFromOrbitalCamera [index] = Vector3.Distance (transform.position, tempHit.point);
					tempFloat = Mathf.Clamp ((Vector3.Distance (transform.position, tempHit.point)), tempFloat * 0.5f, CameraSettings.orbital.maxDistance);
				}
			}
			if (CameraSettings.orbital.rotateWhenClick) {
				if (Input.GetKey (CameraSettings.orbital.keyToRotate)) {
					xOrbit [index] += Input.GetAxis (CameraSettings.inputMouseX) * (CameraSettings.orbital.sensibility * distanceFromOrbitalCamera [index]) / (distanceFromOrbitalCamera [index] * 0.5f);
					yOrbit [index] -= Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.orbital.sensibility * (CameraSettings.orbital.speedYAxis * 10.0f);
				}
			} else {
				xOrbit [index] += Input.GetAxis (CameraSettings.inputMouseX) * (CameraSettings.orbital.sensibility * distanceFromOrbitalCamera [index]) / (distanceFromOrbitalCamera [index] * 0.5f);
				yOrbit [index] -= Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.orbital.sensibility * (CameraSettings.orbital.speedYAxis * 10.0f);
			}
			yOrbit [index] = ClampAngle (yOrbit [index], CameraSettings.orbital.minAngleY, CameraSettings.orbital.maxAngleY);
			tempRotation2 = Quaternion.Euler (yOrbit [index], xOrbit [index], 0);
			distanceFromOrbitalCamera [index] = Mathf.Clamp (distanceFromOrbitalCamera [index] - Input.GetAxis (CameraSettings.inputMouseScrollWheel) * (CameraSettings.orbital.speedScrool * 50.0f), tempFloat, CameraSettings.orbital.maxDistance);
			negPosition = new Vector3 (0.0f, 0.0f, -distanceFromOrbitalCamera [index]);
			otherPosition = tempRotation2 * negPosition + transform.position;
			newPosition = cameras [index]._camera.transform.position;
			tempRotation = cameras [index]._camera.transform.rotation;
			cameras [index]._camera.transform.rotation = Quaternion.Lerp(tempRotation,tempRotation2,Time.deltaTime*5.0f*timeScaleSpeed);
			cameras [index]._camera.transform.position = Vector3.Lerp(newPosition,otherPosition,Time.deltaTime*5.0f*timeScaleSpeed);
			break;
		case CameraType.TipoRotac.OrbitalThatFollows:
			if (CameraSettings.OrbitalThatFollows.rotateWhenClick) {
				if (Input.GetKey (CameraSettings.OrbitalThatFollows.keyToRotate)) {
					movXTemp = Input.GetAxis (CameraSettings.inputMouseX);
					movYTemp = Input.GetAxis (CameraSettings.inputMouseY);
				}
			} else {
				movXTemp = Input.GetAxis (CameraSettings.inputMouseX);
				movYTemp = Input.GetAxis (CameraSettings.inputMouseY);
			}
			movZTemp = Input.GetAxis (CameraSettings.inputMouseScrollWheel);
			if (movXTemp > 0.0f || movYTemp > 0.0f || movZTemp > 0.0f) {
				orbitalAtiv = true;
				tempoOrbit = 0.0f;
			} else {
				tempoOrbit += Time.deltaTime;
			}
			if (tempoOrbit > 3.0f) {
				tempoOrbit = 3.1f;
				orbitalAtiv = false;
			}
			if(orbitalAtiv == true){
				tempFloat = CameraSettings.OrbitalThatFollows.minDistance;
				if (!Physics.Linecast (transform.position, cameras [index]._camera.transform.position)) {

				} else if (Physics.Linecast (transform.position, cameras [index]._camera.transform.position, out tempHit)) {
					if (!CameraSettings.OrbitalThatFollows.ignoreCollision) {
						distanceFromOrbitalCamera [index] = Vector3.Distance (transform.position, tempHit.point);
						tempFloat = Mathf.Clamp ((Vector3.Distance (transform.position, tempHit.point)), tempFloat * 0.5f, CameraSettings.OrbitalThatFollows.maxDistance);
					}
				}
				xOrbit [index] += movXTemp * (CameraSettings.OrbitalThatFollows.sensibility * distanceFromOrbitalCamera [index]) / (distanceFromOrbitalCamera [index] * 0.5f);
				yOrbit [index] -= movYTemp * CameraSettings.OrbitalThatFollows.sensibility * (CameraSettings.OrbitalThatFollows.speedYAxis * 10.0f);
				yOrbit [index] = ClampAngle (yOrbit [index], CameraSettings.OrbitalThatFollows.minAngleY, CameraSettings.OrbitalThatFollows.maxAngleY);
				tempRotation2 = Quaternion.Euler (yOrbit [index], xOrbit [index], 0);
				distanceFromOrbitalCamera [index] = Mathf.Clamp (distanceFromOrbitalCamera [index] - movZTemp * (CameraSettings.OrbitalThatFollows.speedScrool * 50.0f), tempFloat, CameraSettings.OrbitalThatFollows.maxDistance);
				negPosition = new Vector3 (0.0f, 0.0f, -distanceFromOrbitalCamera [index]);
				otherPosition = tempRotation2 * negPosition + transform.position;
				newPosition = cameras [index]._camera.transform.position;
				tempRotation = cameras [index]._camera.transform.rotation;
				cameras [index]._camera.transform.rotation = Quaternion.Lerp (tempRotation, tempRotation2, Time.deltaTime * 5.0f * timeScaleSpeed);
				cameras [index]._camera.transform.position = Vector3.Lerp (newPosition, otherPosition, Time.deltaTime * 5.0f * timeScaleSpeed);
			} else {
				if (!Physics.Linecast (transform.position, originalPosition [index].transform.position)) {
					cameras [index]._camera.transform.position = Vector3.Lerp (cameras [index]._camera.transform.position, originalPosition [index].transform.position, Time.deltaTime * CameraSettings.OrbitalThatFollows.displacementSpeed);
				}
				else if(Physics.Linecast(transform.position, originalPosition [index].transform.position,out tempHit)){
					if (CameraSettings.OrbitalThatFollows.ignoreCollision) {
						cameras [index]._camera.transform.position = Vector3.Lerp (cameras [index]._camera.transform.position, originalPosition [index].transform.position, Time.deltaTime * CameraSettings.OrbitalThatFollows.displacementSpeed);
					} 
					else {
						cameras [index]._camera.transform.position = Vector3.Lerp(cameras [index]._camera.transform.position, tempHit.point,Time.deltaTime * CameraSettings.OrbitalThatFollows.displacementSpeed);
					}
				}
				//
				if (CameraSettings.OrbitalThatFollows.customLookAt) {
					tempRotation = Quaternion.LookRotation (transform.position - cameras [index]._camera.transform.position, Vector3.up);
					cameras [index]._camera.transform.rotation = Quaternion.Slerp (cameras [index]._camera.transform.rotation, tempRotation, Time.deltaTime * CameraSettings.OrbitalThatFollows.spinSpeedCustomLookAt);
				} else {
					cameras [index]._camera.transform.LookAt (transform.position);
				}
			}
			break;
		case CameraType.TipoRotac.ETS_StyleCamera:
			if (CameraSettings.ETS_StyleCamera.rotateWhenClick) {
				if (Input.GetKey (CameraSettings.ETS_StyleCamera.keyToRotate)) {
					rotacXETS += Input.GetAxis (CameraSettings.inputMouseX) * CameraSettings.ETS_StyleCamera.sensibilityX;
					rotacYETS += Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.ETS_StyleCamera.sensibilityY;
				}
			} else {
				rotacXETS += Input.GetAxis (CameraSettings.inputMouseX) * CameraSettings.ETS_StyleCamera.sensibilityX;
				rotacYETS += Input.GetAxis (CameraSettings.inputMouseY) * CameraSettings.ETS_StyleCamera.sensibilityY;
			}
			newPosition = new Vector3 (originalPositionETS [index].x + Mathf.Clamp (rotacXETS / 50 + (CameraSettings.ETS_StyleCamera.ETS_CameraShift/3.0f), -CameraSettings.ETS_StyleCamera.ETS_CameraShift, 0), originalPositionETS [index].y, originalPositionETS [index].z);
			cameras [index]._camera.transform.localPosition = Vector3.Lerp (cameras [index]._camera.transform.localPosition, newPosition, Time.deltaTime * 10.0f);
			rotacXETS = ClampAngle (rotacXETS, -180, 80);
			rotacYETS = ClampAngle (rotacYETS, -60, 60);
			temp_xQuaternion = Quaternion.AngleAxis (rotacXETS, Vector3.up);
			temp_yQuaternion = Quaternion.AngleAxis (rotacYETS, -Vector3.right);
			tempRotation = originalRotation [index] * temp_xQuaternion * temp_yQuaternion;
			cameras [index]._camera.transform.localRotation = Quaternion.Lerp (cameras [index]._camera.transform.localRotation, tempRotation, Time.deltaTime * 10.0f * timeScaleSpeed);
			//fieldOfView
			cameras [index]._camera.fieldOfView -= Input.GetAxis (CameraSettings.inputMouseScrollWheel)*CameraSettings.ETS_StyleCamera.speedScroolZoom*50.0f;
			if (cameras [index]._camera.fieldOfView < (initialFieldOfView [index] - CameraSettings.ETS_StyleCamera.maxScroolZoom)) {
				cameras [index]._camera.fieldOfView = (initialFieldOfView [index] - CameraSettings.ETS_StyleCamera.maxScroolZoom);
			}
			if (cameras [index]._camera.fieldOfView > initialFieldOfView [index]) {
				cameras [index]._camera.fieldOfView = (initialFieldOfView [index]);
			}
			break;
		}
	}

	public static float ClampAngle (float angle, float min, float max){
		if (angle < -360F) { angle += 360F; }
		if (angle > 360F) { angle -= 360F; }
		return Mathf.Clamp (angle, min, max);
	}

	void Update(){
		if (Time.timeScale > 0) {
			if (Input.GetKeyDown (CameraSettings.cameraSwitchKey) && index < (cameras.Length - 1)) {
				index++;
				EnableCameras (index);
			} else if (Input.GetKeyDown (CameraSettings.cameraSwitchKey) && index >= (cameras.Length - 1)) {
				index = 0;
				EnableCameras (index);
			}
		}
	}

	void LateUpdate(){
		if (cameras.Length > 0 && Time.timeScale > 0) {
			if (cameras [index]._camera) {
				ManageCameras ();
			}
		}
	}
}