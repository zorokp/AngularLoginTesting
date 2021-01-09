
export interface SupplierInterface {
  name: string;
  address: string;
};

export class Supplier implements SupplierInterface {
  name: string;
  address: string;

  constructor(name: string, address: string) {
    this.name = name;
    this.address = address;
  }

}

