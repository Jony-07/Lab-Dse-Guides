package datos;

public class Contacto {
	public Contacto(String nombre, long celular) {
		super();
		this.nombre = nombre;
		this.celular = celular;
	}
	public Contacto() {
		super();
	}
	private String nombre;
	private long celular;
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public long getCelular() {
		return celular;
	}
	public void setCelular(long celular) {
		this.celular = celular;
	}
	@Override
	public String toString() {
		return "Contacto [nombre=" + nombre + ", celular=" + celular + "]";
	}
}
