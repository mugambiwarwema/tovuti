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
  AttributeServiceProxy,
  AttributeDto,
  AttributeValueServiceProxy,
  AttributeValueDto,
  AttributeDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';


@Component({
  templateUrl: 'edit-attributevalue-dialog.component.html'
})
export class EditAttributeValueDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  attribute: AttributeDto = new AttributeDto();
  attributevalue: AttributeValueDto = new AttributeValueDto();
  id: number;
  attributes: AttributeDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _attributeService: AttributeServiceProxy,
    public _attributeValueService: AttributeValueServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._attributeValueService.get(this.id).subscribe((result: AttributeValueDto) => {
      this.attributevalue = result;
    });
    this.getAttributeList();
    this.attributevalue.attributeId 
  }

  
  getAttributeList(): void {
    this._attributeService
      .getAll( "", 0, 100)
      .pipe( finalize(() => {}))
      .subscribe((result: AttributeDtoPagedResultDto) => { this.attributes = result.items;});
  }

  save(): void {
    this.saving = true;

    this._attributeValueService.update(this.attributevalue).subscribe(
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
