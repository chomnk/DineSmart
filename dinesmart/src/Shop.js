import './shop.css'

function Shop(props) {
    const shopId = props.shopId;
    const shopToggle = props.shopToggle;

    return (
        <div className="shop">
            <div className="shop_left">
                <div className="shop_left_top">
                    {/*TODO: insert shop name here*/}
                </div>
                <div className="shop_left_middle">
                    {/*TODO: insert shop sentimental analysis here*/}
                </div>
                <div className="shop_left_bottom" onClick={() => shopToggle(null)}>

                </div>
            </div>
            <div className="shop_right">
                <div className="shop_right_top">
                    <div className="shop_right_top_left"></div>
                    <div className="shop_right_top_right"></div>
                </div>
                <div className="shop_right_middle"></div>
                <div className="shop_right_bottom"></div>
            </div>
        </div>
    );
}

export default Shop;