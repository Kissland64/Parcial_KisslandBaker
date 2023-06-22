using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class GastoBLL
{

    public Context _context { get; set; }
    public GastoBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int gastoId)
    {
        return _context.gastos.Any(i => i.GastoId == gastoId);
    }

    public bool Insertar(Gasto gasto)
    {
        _context.gastos.Add(gasto);
        return _context.SaveChanges() > 0;
    }

    public bool Guardar(Gasto gasto)
    {
        if (!Existe(gasto.GastoId))
            return Insertar(gasto);
        else
            return Modificar(gasto);
    }

    public bool Modificar(Gasto gasto)
    {
        _context.gastos.Entry(gasto).State = EntityState.Modified;
        return _context.SaveChanges() > 0;
    }

    public bool Eliminar(Gasto gasto)
    {
        _context.gastos.Remove(gasto);
        int eliminado = _context.SaveChanges();
        return eliminado > 0;
    }

    public Gasto? Buscar(int gastoId)
    {
        return _context.gastos.Where(i => i.GastoId == gastoId)
            .AsNoTracking()
            .SingleOrDefault();
    }

    public List<Gasto> Listar(Expression<Func<Gasto, bool>> criterio)
    {
        return _context.gastos
            .Where(criterio)
            .AsNoTracking().ToList();
    }
}