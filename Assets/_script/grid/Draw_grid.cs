using grid.cell;

namespace grid
{
	public class Draw_grid : Grid {

		protected override Cell _instanciate_cell( int column, int row ) {
			Cell cell = base._instanciate_cell( column, row );
			cell.gameObject.SetActive( true );
			return cell;
		}

		public override void resize() {
			_collider.enabled = true;
			base.resize();
			_collider.enabled = false;
		}
	}
}