type Intento = {
    numero: string;
    picas: number;
    famas: number;
};

type TablaIntentosProps = {
    historial: Intento[];
};

function TablaIntentos({ historial }: TablaIntentosProps) {
    if (historial.length === 0) {
        return null;
    }

    return (
        <>
            <hr />

            <h3>Historial de intentos</h3>

            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Número</th>
                        <th>Picas</th>
                        <th>Famas</th>
                    </tr>
                </thead>

                <tbody>
                    {historial.map((intento, index) => (
                        <tr key={index}>
                            <td>{index + 1}</td>
                            <td>{intento.numero}</td>
                            <td>{intento.picas}</td>
                            <td>{intento.famas}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
}

export default TablaIntentos;