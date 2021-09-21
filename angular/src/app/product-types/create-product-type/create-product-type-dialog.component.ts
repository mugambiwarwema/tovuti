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
  InputProductTypeDto,
  ProductTypeServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-product-type-dialog.component.html'
})
export class CreateProductTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  productType: InputProductTypeDto = new InputProductTypeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productTypeService: ProductTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._productTypeService.create(this.productType).subscribe(
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
