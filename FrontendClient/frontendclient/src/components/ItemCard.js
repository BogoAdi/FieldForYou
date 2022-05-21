import CustomisedCard from './CustomisedCard'

const ItemCard = ({sportField}) => {
   
    return (
        <div>
            {sportField.map((sportField, index) => (
                <CustomisedCard
                    key={index}
                    id={sportField.id}
                    name={sportField.name}
                    image={sportField.img}
                    address={sportField.address}
                    city={sportField.city}
                    category={sportField.category}
                    description={sportField.description}
                    price={sportField.pricePerHour}
                />
            ))}
        </div>
    );
    }
    export default ItemCard;