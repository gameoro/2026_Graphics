using UnityEditor;
using UnityEngine;

public class RenderCubemapWizard : ScriptableWizard {

	public Camera cam;

	private void OnWizardUpdate() {
		helpString = "Select cam pos";
		isValid = (cam != null);
	}

	private void OnWizardCreate() {
		Cubemap cubemap = new Cubemap(512, TextureFormat.ARGB32, false);
		cam.RenderToCubemap(cubemap);

		AssetDatabase.CreateAsset(cubemap, $"Assets/6_FakeInterior/Cubemaps/{cam.name}.cubemap");
	}

	[MenuItem("Tools/Cubemap Wizard")]
	static void RenderCubemap() {
		DisplayWizard<RenderCubemapWizard>("Render Cubemap", "Render");
	}
}