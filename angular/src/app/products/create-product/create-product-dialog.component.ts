import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  InputProductDto,
  ProductServiceProxy,
  ProductTypeDto,
  ProductTypeDtoPagedResultDto,
  ProductTypeServiceProxy
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: 'create-product-dialog.component.html'
})
export class CreateProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  product: InputProductDto = new InputProductDto();
  productTypes: ProductTypeDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    public _productTypeService: ProductTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getProductTypeList()
  }

  getProductTypeList(): void {
    this._productTypeService
      .getAll( "", 0, 100)
      .pipe( finalize(() => {}))
      .subscribe((result: ProductTypeDtoPagedResultDto) => { this.productTypes = result.items;});
  }


  save(): void {
    this.saving = true;

    this._productService.create(this.product).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
