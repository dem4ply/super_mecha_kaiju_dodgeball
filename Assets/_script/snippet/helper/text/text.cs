using UnityEngine;

namespace helper
{
	public static class text
	{
		public static TextMesh _( string text, Transform parent, Vector3 position, int size )
		{
			return _( text, parent, position, size, Quaternion.identity );
		}

		public static TextMesh _( string text, Transform parent, Vector3 position, int size, Quaternion rotation )
		{
			return _( text, parent, position, size, rotation, TextAnchor.UpperLeft );
		}

		public static TextMesh _(
			string text, Transform parent, Vector3 position, int size, Quaternion rotation,
			TextAnchor anchor=TextAnchor.UpperLeft )
		{
			GameObject obj = new GameObject( string.Format( "text {0}", text ), typeof( TextMesh ) );
			obj.transform.parent = parent;
			obj.transform.localPosition = position;
			obj.transform.rotation = rotation;
			TextMesh text_mesh = obj.GetComponent<TextMesh>();
			text_mesh.text = text;
			text_mesh.anchor = anchor;
			text_mesh.fontSize = size;
			return text_mesh;
		}
	}
}
